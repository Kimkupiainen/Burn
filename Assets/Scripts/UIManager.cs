using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button m_changeViewButton;
    [SerializeField] private Slider m_sanitySlider;
    [SerializeField] private GameObject m_endPanel;
    [SerializeField] private Button m_restartButton;
    [SerializeField] private GameObject m_inspectionPanel;
    [SerializeField] private Button m_closeInspectionButton;
    [SerializeField] private Button m_nextPageButton;
    [SerializeField] private Button m_previousPageButton;
    [SerializeField] private TMP_Text m_sanityText;

    [SerializeField] private TMP_Text m_cultistPerDayText;
    private Player m_player;


    private void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        m_changeViewButton.onClick.AddListener(ChangeView);
        m_endPanel.SetActive(false);
        m_inspectionPanel.SetActive(false);
        m_restartButton.onClick.AddListener(() => {
            UnityEngine.SceneManagement.SceneManager.LoadScene("kimscene");
        });
        m_closeInspectionButton.onClick.AddListener(() => {
            m_player.EndItemInspect();
            m_inspectionPanel.SetActive(false);
        });
        m_nextPageButton.onClick.AddListener(() => {
            FindObjectOfType<CultManual>().PageForward();
        });
        m_previousPageButton.onClick.AddListener(() => {
            FindObjectOfType<CultManual>().PageBackward();
        });
    }

    private void ChangeView() {
        m_player.OnChangeView();
    }

    public void UpdateSanitySlider(float value) {
        m_sanitySlider.value = value;
    }

    public void UpdateSanityText(int value, int maxValue) {
        m_sanityText.text = value + "/" + maxValue;
    }

    public void UpdateCultistText() {
        m_cultistPerDayText.text = GameManager.Instance.CurrentCultistIndex + "/" + GameManager.Instance.MaxCultistPerDay;
    }

    public void EndGame() {
        m_endPanel.SetActive(true);
    }

    public void ShowInspectionPanel(bool isManual) {
        m_nextPageButton.gameObject.SetActive(isManual);
        m_previousPageButton.gameObject.SetActive(isManual);
        m_inspectionPanel.SetActive(true);
    }
}
