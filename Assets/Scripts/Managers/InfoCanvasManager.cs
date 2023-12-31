using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoCanvasManager : Singleton<InfoCanvasManager>
{
    public bool IsTutorialShown = false;
    [SerializeField] private GameObject m_tutorialPanel;
    [SerializeField] private Button m_closeButton;

    [SerializeField] private GameObject m_infoPanel;
    [SerializeField] private Button m_nextDayButton;

    [SerializeField] private TMP_Text m_dayText;
    [SerializeField] private TMP_Text m_totalRecruitedText;
    [SerializeField] private TMP_Text m_totalBurnedText;
    [SerializeField] private TMP_Text m_believersRecruitedText;
    [SerializeField] private TMP_Text m_believersBurnedText;
    [SerializeField] private TMP_Text m_hereticsRecruitedText;
    [SerializeField] private TMP_Text m_hereticsBurnedText;

    private CanvasGroup canvasGroup;

    [SerializeField] private GameObject m_dayLabel;
    [SerializeField] private GameObject m_congratsText;
    [SerializeField] private Button m_toMainMenuButton;

    private void Start() {
        m_tutorialPanel.SetActive(!IsTutorialShown);
        m_closeButton.onClick.AddListener(() => {
            IsTutorialShown = true;
            m_tutorialPanel.SetActive(false);
        });
        m_nextDayButton.onClick.AddListener(() => {
            GameManager.Instance.StartDay();
        });
        m_toMainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        m_infoPanel.SetActive(false);
        m_dayLabel.SetActive(true);
        m_congratsText.SetActive(false);
        m_dayText.gameObject.SetActive(true);
        m_nextDayButton.gameObject.SetActive(true);
        m_toMainMenuButton.gameObject.SetActive(false);
    }

    public void UpdateInfos() {
        m_dayText.text = GameManager.Instance.DayCount.ToString();

        m_totalRecruitedText.text = GameManager.Instance.TotalRecruited.ToString();
        m_totalBurnedText.text = GameManager.Instance.TotalBurned.ToString();

        m_believersRecruitedText.text = GameManager.Instance.BelieverRecruit.ToString();
        m_believersBurnedText.text = GameManager.Instance.BelieverBurn.ToString();

        m_hereticsRecruitedText.text = GameManager.Instance.HereticRecruit.ToString();
        m_hereticsBurnedText.text = GameManager.Instance.HereticBurn.ToString();

        //EndGame
        if(GameManager.Instance.DayCount >= GameManager.Instance.MaxDays) {
            m_dayLabel.SetActive(false);
            m_dayText.gameObject.SetActive(false);
            m_congratsText.SetActive(true);
            m_nextDayButton.gameObject.SetActive(false);
            m_toMainMenuButton.gameObject.SetActive(true);
        }
    }

    public IEnumerator FadeInCoroutine() {
        m_infoPanel.SetActive(true);
        canvasGroup.alpha = 0;
        while(canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime * 2;
            yield return null;
        }
    }

    public IEnumerator FadeOutCoroutine() {
        canvasGroup.alpha = 1;
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        m_infoPanel.SetActive(false);
    }
}
