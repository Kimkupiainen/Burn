using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button m_changeViewButton;
    [SerializeField] private Slider m_sanitySlider;
    [SerializeField] private GameObject m_endPanel;
    [SerializeField] private Button m_restartButton;
    private Player m_player;


    private void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_changeViewButton.onClick.AddListener(ChangeView);
        m_endPanel.SetActive(false);
        m_restartButton.onClick.AddListener(() => {
            UnityEngine.SceneManagement.SceneManager.LoadScene("kimscene");
        });
    }

    private void ChangeView() {
        m_player.OnChangeView();
    }

    public void UpdateSanitySlider(float value) {
        m_sanitySlider.value = value;
    }

    public void EndGame() {
        m_endPanel.SetActive(true);
    }
}
