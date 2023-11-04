using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
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

    private void Update() {
        if (m_targetTransform != null) {
            transform.position = m_targetTransform.position;
        }
    }
}
