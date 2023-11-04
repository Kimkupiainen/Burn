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
    private Vector3 m_handTargetPos;
    [SerializeField] private float m_handSpeed = 1;
    private LayerMask pickupLayermask;
    private LayerMask handMoveMask;

    private Interactable m_heldItem;
    void Start()
    {
        m_camera = Camera.main;
        m_handTargetPos = m_hand.transform.position;
        m_hand.SetActive(false);
        pickupLayermask = ~(1 << LayerMask.NameToLayer("Interactable"));
        handMoveMask = 1 << LayerMask.NameToLayer("Table");
    }

    // Update is called once per frame
    void Update()
    {
        HandleHandMove();
    }

    private void OnInteract(InputValue value) {
        if(!m_showHand) {
            return;
        }
        if(m_heldItem != null) {
            if(!Physics.Raycast(m_hand.transform.position, -transform.up, out RaycastHit tableHit, Mathf.Infinity, pickupLayermask)) {
                return;
            }
            m_heldItem.SetTargetTransform(null);
            m_heldItem = null;
            return;
        }
        if (!Physics.Raycast(m_pickUpPoint.position, -transform.up, out RaycastHit hit, Mathf.Infinity)) {
            return;
        }
        if (!hit.transform.CompareTag("Interactable")) {
            return;
        }
        m_heldItem = hit.transform.GetComponent<Interactable>();
        m_heldItem.SetTargetTransform(m_pickUpPoint);
        
    }

    public void OnChangeView() {
        CameraManager.Instance.ChangeCameraPosition();
        m_showHand = !m_showHand;
        m_hand.SetActive(m_showHand);
        if(!m_showHand) {
            ResetValues();
        }
    }

    private void OnMoveHand(InputValue value) {
        Ray ray = m_camera.ScreenPointToRay(value.Get<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, handMoveMask)) {
            m_handTargetPos = hit.point;
        }
    }

    private void HandleHandMove() {
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
}
