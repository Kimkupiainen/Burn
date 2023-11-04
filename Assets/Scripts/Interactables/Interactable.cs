using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]private List<TMP_Text> m_infoTexts;
    private Transform m_targetTransform;
    private float startY;

    private void Start() {
        startY = transform.position.y;
    }

    public void SetTargetTransform(Transform targetTransform = null) {
        if (targetTransform == null) {
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.rotation;
            return;
        }
        transform.rotation = targetTransform.rotation;
        transform.position = targetTransform.position;
    }

    public void SetText(string text) {
        if(m_infoTexts == null) {
            return;
        }
        string[] infos = text.Split(",");
        for (int i = 0; i < m_infoTexts.Count; i++) {
            m_infoTexts[i].text = infos[i];
        }
        /*if(m_infoText == null) {
            return;
        }
        m_infoText.text = text;*/
    }
}
