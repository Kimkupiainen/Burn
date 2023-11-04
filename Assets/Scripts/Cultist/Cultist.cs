using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    [SerializeField] private Transform m_modelParent;
    private Transform m_walkTarget;
    private bool m_isInited = false;
    private bool m_isFinalDestinationSet;
    private bool m_isWalking = false;

    public string CultistInfo {
        get; private set;
    }
    public bool Acceptable {
        get; private set;
    }

    public void Init(GameObject cultistModel) {
        Instantiate(cultistModel, m_modelParent);
        CultistInfo = attributeList.Instance.printAttributes();
        Acceptable = attributeList.Instance.acceptable;
        m_isInited = true;
    }

    public void SetWalkTarget(Transform walkTarget, bool isFinalDestination = false) {
        m_walkTarget = walkTarget;
        m_isFinalDestinationSet = isFinalDestination;
        m_isWalking = true;
    }

    private void Update() {
        if (!m_isInited) {
            return;
        }

        HandleMovement();
    }

    private void HandleMovement() {
        if(!m_isWalking) {
            return;
        }
        if(transform.position == m_walkTarget.position) {
            m_isWalking = false;
            if(m_isFinalDestinationSet) {
                FulfillDestiny();
                return;
            }
            CultistManager.Instance.CultistAtTable();
            return;
        }

        Vector3 dir = (m_walkTarget.position - transform.position).normalized;
        float distanceToDestination = Vector3.Distance(m_walkTarget.position, transform.position);
        Vector3 move = dir * CultistManager.Instance.cultistMoveSpeed * Time.deltaTime;
        if (move.magnitude > distanceToDestination) {
            transform.position = m_walkTarget.position;
            return;
        }
        transform.position += move;
    }

    private void FulfillDestiny() {
        CultistManager.Instance.SpawnCultist();
        Destroy(gameObject);
    }
}
