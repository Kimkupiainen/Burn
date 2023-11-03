using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Camera m_camera;
    private bool m_showHand = false;
    [SerializeField] private GameObject m_hand;
    private Vector3 m_handTargetPos;
    [SerializeField] private float m_handSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        m_handTargetPos = m_hand.transform.position;
        m_hand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_showHand) {
            if(Vector3.Distance(m_handTargetPos, m_hand.transform.position) >= .1f) {
                Vector3 dir = (m_handTargetPos - m_hand.transform.position).normalized;
                dir.y = 0;
                m_hand.transform.position += dir * m_handSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTest() {
        //Debug.Log("asd");
    }

    private void OnChangeView() {
        CameraManager.Instance.ChangeCameraPosition();
        m_showHand = !m_showHand;
        m_hand.SetActive(m_showHand);
    }

    private void OnMoveHand(InputValue value) {
        Ray ray = m_camera.ScreenPointToRay(value.Get<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            m_handTargetPos = hit.point;
        }
    }
}
