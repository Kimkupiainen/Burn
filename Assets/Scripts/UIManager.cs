using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button m_changeViewButton;
    private Player m_player;


    private void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_changeViewButton.onClick.AddListener(ChangeView);
    }

    private void ChangeView() {
        m_player.OnChangeView();
    }
}
