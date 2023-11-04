using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CultManual : MonoBehaviour
{
    private PageData[] m_pages;
    [SerializeField] private GameObject firstPage;
    [SerializeField] private GameObject secondPage;
    [SerializeField] private TMP_Text m_firstPageText;
    [SerializeField] private TMP_Text m_secondPageText;

    private int m_currentPageIndex = 0;

    private void Start() {
        m_pages = Resources.LoadAll<PageData>("PageDatas");
        SetPage();
    }

    public void PageForward() {
        if(m_currentPageIndex < m_pages.Length - 2) {
            m_currentPageIndex += 2;
        }
        SetPage();
    }

    public void PageBackward() {
        if (m_currentPageIndex > 1) {
            m_currentPageIndex -= 2;
        }
        SetPage();
    }

    private void SetPage() {
        m_firstPageText.text = m_pages[m_currentPageIndex].content;
        if(m_currentPageIndex < m_pages.Length - 1) {
            m_secondPageText.text = m_pages[m_currentPageIndex + 1].content;
            secondPage.SetActive(true);
        }
        else {
            secondPage.SetActive(false);
        }
    }
}
