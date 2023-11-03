using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] CinemachineVirtualCamera m_camera;

    [SerializeField] private Transform m_cameraDefaultPos;
    [SerializeField] private Transform m_cameraInspectionPos;

    private Transform m_cameraTargetPos;

    private void Start() {
        ChangeCameraPosition();
    }

    public void ChangeCameraPosition() {
        if(m_cameraTargetPos == m_cameraDefaultPos) {
            m_cameraTargetPos = m_cameraInspectionPos;
        }
        else {
            m_cameraTargetPos = m_cameraDefaultPos;
        }

        m_camera.Follow = m_cameraTargetPos;
    }
}
