using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    [SerializeField] private Transform m_modelParent;
    private Transform m_walkTarget;
    private bool m_isInited = false;
    private bool m_isFinalDestinationSet;

    public void Init(GameObject cultistModel) {
        Instantiate(cultistModel, m_modelParent);
        m_isInited = true;
    }

    public void SetWalkTarget(Transform walkTarget, bool isFinalDestination = false) {
        m_walkTarget = walkTarget;
        m_isFinalDestinationSet = isFinalDestination;
    }

    private void Update() {
        if (!m_isInited) {
            return;
        }

        HandleMovement();
    }

    private void HandleMovement() {
        if(transform.position == m_walkTarget.position) {
            if(m_isFinalDestinationSet) {
                FulfillDestiny();
            }
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
