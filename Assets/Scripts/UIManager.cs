using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private UIDocument m_document;
    private Button m_button;

    private void OnEnable() {
        m_document = GetComponent<UIDocument>();

        if(m_document == null) {
            Debug.Log("Error");
        }
        m_button = m_document.rootVisualElement.Q("ChangeViewButton") as Button;
        m_button.RegisterCallback<ClickEvent>(ChangeCameraPosition);
    }

    private void ChangeCameraPosition(ClickEvent e) {
        CameraManager.Instance.ChangeCameraPosition();
    }
}
