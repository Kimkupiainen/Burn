using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteButton : MonoBehaviour
{
    [SerializeField] private bool m_isYesButton;
    public void Interact() {
        if (m_isYesButton) {
            CultistManager.Instance.AcceptCultist();
        }
        else {
            CultistManager.Instance.DeclineCultist();
        }
    }
}
