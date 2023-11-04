using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistManager : Singleton<CultistManager>
{
    [SerializeField] GameObject m_cultistBase;
    [SerializeField] GameObject m_cultistModel;
    [SerializeField] private Transform m_cultistSpawnPoint;
    [SerializeField] private Transform m_cultistWalkPoint;
    [SerializeField] private Transform m_cultistGoalWalkPoint;
    private Cultist m_currentCultist;
    public float cultistMoveSpeed = 3;

    private float m_canCultistProceed;

    private void Start() {
        SpawnCultist();
    }

    public void SpawnCultist() {
        m_currentCultist = Instantiate(m_cultistBase, m_cultistSpawnPoint).GetComponent<Cultist>();
        m_currentCultist.SetWalkTarget(m_cultistWalkPoint);
        m_currentCultist.Init(m_cultistModel);
    }

    public void Update() {
        if(m_canCultistProceed > 4) {
            m_currentCultist.SetWalkTarget(m_cultistGoalWalkPoint, true);
            m_canCultistProceed = 0;
        }
        else {
            m_canCultistProceed += Time.deltaTime;
        }
    }
}
