using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button m_changeViewButton;

    private void Start() {
        m_changeViewButton.onClick.AddListener(ChangeView);
    }

    private void ChangeView() {
        CameraManager.Instance.ChangeCameraPosition();
    }
}
