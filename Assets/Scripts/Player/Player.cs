using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Camera m_camera;
    private bool m_showHand = false;
    [SerializeField] private GameObject m_hand;
    [SerializeField] private Transform m_pickUpPoint;
    [SerializeField] private Transform m_inspectionTransform;
    private Vector3 m_handTargetPos;
    [SerializeField] private float m_handSpeed = 1;
    private LayerMask pickupLayermask;
    private LayerMask handMoveMask;
    private Vector2 m_mousePos;
    private bool m_isInspecting;

    private Interactable m_heldItem;
    [SerializeField] private int m_maxSanity = 10;
    private int m_currentSanity;
    public float SanityNormalized {
        get {
            return (float)m_currentSanity / (float)m_maxSanity;
        }
    }
    void Start()
    {
        m_camera = Camera.main;
        m_handTargetPos = m_hand.transform.position;
        m_hand.SetActive(false);
        pickupLayermask = ~(1 << LayerMask.NameToLayer("Interactable"));
        handMoveMask = 1 << LayerMask.NameToLayer("Table");
        m_currentSanity = m_maxSanity;
        //UIManager.Instance.UpdateSanitySlider(SanityNormalized);
        UIManager.Instance.UpdateSanityText(m_currentSanity, m_maxSanity);
    }

    // Update is called once per frame
    void Update()
    {
        HandleHandMove();
    }

    private void OnInteract(InputValue value) {
        if(GameManager.Instance.IsDayEnded) {
            return;
        }
        if(GameManager.Instance.IsGameLost) {
            return;
        }
        if (m_isInspecting) {
            return;
        }
        if (!m_showHand) {
            HandleVoteButtonInteract();
            return;
        }
        HandleDocumentInteract();
    }

    public void OnChangeView() {
        if (GameManager.Instance.IsDayEnded) {
            return;
        }
        if (GameManager.Instance.IsGameLost) {
            return;
        }
        if(m_isInspecting) {
            return;
        }
        if (!CultistManager.Instance.IsCultistAtTable) {
            return;
        }
        CameraManager.Instance.ChangeCameraPosition();
        m_showHand = !m_showHand;
        m_hand.SetActive(m_showHand);
        if(!m_showHand) {
            ResetValues();
        }
    }

    private void OnMoveHand(InputValue value) {
        if (GameManager.Instance.IsDayEnded) {
            return;
        }
        if (m_isInspecting) {
            return;
        }
        m_mousePos = value.Get<Vector2>();
        Ray ray = m_camera.ScreenPointToRay(m_mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, handMoveMask)) {
            m_handTargetPos = hit.point;
        }
    }

    private void HandleVoteButtonInteract() {
        if (GameManager.Instance.IsDayEnded) {
            return;
        }
        if (GameManager.Instance.IsGameLost) {
            return;
        }
        if (m_isInspecting) {
            return;
        }
        Ray ray = m_camera.ScreenPointToRay(m_mousePos);
        if (!Physics.Raycast(ray, out RaycastHit buttonHit, Mathf.Infinity, handMoveMask)) {
            return;
        }
        if (!buttonHit.transform.CompareTag("VoteButton")) {
            return;
        }
        buttonHit.transform.GetComponent<VoteButton>().Interact();
    }

    private void HandleDocumentInteract() {
        if (GameManager.Instance.IsDayEnded) {
            return;
        }
        if (GameManager.Instance.IsGameLost) {
            return;
        }

        if (m_isInspecting) {
            return;
        }

        /*if (m_heldItem != null) {
            if (!Physics.Raycast(m_hand.transform.position, -transform.up, Mathf.Infinity, pickupLayermask)) {
                return;
            }
            m_heldItem.SetTargetTransform(null);
            m_heldItem = null;
            return;
        }*/
        if (!Physics.Raycast(m_pickUpPoint.position, -transform.up, out RaycastHit hit, Mathf.Infinity)) {
            return;
        }
        if (!hit.transform.CompareTag("Interactable")) {
            return;
        }
        m_heldItem = hit.transform.GetComponent<Interactable>();
        m_heldItem.SetTargetTransform(m_inspectionTransform);
        m_isInspecting = true;
        UIManager.Instance.ShowInspectionPanel(hit.transform.name == "CultManual");
    }

    private void HandleHandMove() {
        if (GameManager.Instance.IsDayEnded) {
            return;
        }
        if (GameManager.Instance.IsGameLost) {
            return;
        }
        if (m_isInspecting) {
            return;
        }
        if (!m_showHand) {
            return;
        }
        if (Vector3.Distance(m_handTargetPos, m_hand.transform.position) < .01f) {
            return;
        }
        Vector3 dir = (m_handTargetPos - m_hand.transform.position).normalized;
        dir.y = 0;
        m_hand.transform.position += dir * m_handSpeed * Time.deltaTime;
    }

    private void ResetValues() {
        if(m_heldItem) {
            m_heldItem.SetTargetTransform(null);
        }
        m_heldItem = null;
    }

    public void UpdateSanity(int value) {
        m_currentSanity += value;
        if(m_currentSanity <= 0) {
            m_currentSanity = 0;
            GameManager.Instance.EndGame();
        }
        else if(m_currentSanity > m_maxSanity) {
            m_currentSanity = m_maxSanity;
        }
        //UIManager.Instance.UpdateSanitySlider(SanityNormalized);
        UIManager.Instance.UpdateSanityText(m_currentSanity, m_maxSanity);
    }

    public void EndItemInspect() {
        m_isInspecting = false;
        m_heldItem.SetTargetTransform();
    }
}
