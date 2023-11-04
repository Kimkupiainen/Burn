using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]private TMP_Text m_infoText;
    private Transform m_targetTransform;
    private float startY;

    private void Start() {
        startY = transform.position.y;
    }

    public void SetTargetTransform(Transform targetTransform) {
        if (targetTransform == null) {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
        m_targetTransform = targetTransform;
    }

    public void SetText(string text) {
        if(m_infoText == null) {
            return;
        }
        m_infoText.text = text;
    }

    private void Update() {
        if (m_targetTransform != null) {
            transform.position = m_targetTransform.position;
        }
    }
}
