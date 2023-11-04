using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistManager : Singleton<CultistManager>
{
    [SerializeField] GameObject m_cultistBase;
    [SerializeField] GameObject m_cultistModel;
    [SerializeField] GameObject m_documentPrefab;
    [SerializeField] private List<Transform> m_documentSpawns;
    [SerializeField] private Transform m_cultistSpawnPoint;
    [SerializeField] private Transform m_cultistWalkPoint;
    [SerializeField] private Transform m_cultistGoalWalkPoint;
    private Cultist m_currentCultist;
    public float cultistMoveSpeed = 3;
    private GameObject m_spawnedDocument;

    private void Start() {
        SpawnCultist();
    }

    public void SpawnCultist() {
        m_currentCultist = Instantiate(m_cultistBase, m_cultistSpawnPoint).GetComponent<Cultist>();
        m_currentCultist.SetWalkTarget(m_cultistWalkPoint);
        m_currentCultist.Init(m_cultistModel);
    }

    public void CultistAtTable() {
        Transform documentSpawn = m_documentSpawns[Random.Range(0, m_documentSpawns.Count)];
        m_spawnedDocument = Instantiate(m_documentPrefab, documentSpawn);
        m_spawnedDocument.GetComponent<Interactable>().SetText(m_currentCultist.CultistInfo);
    }

    public void AcceptCultist() {
        Destroy(m_spawnedDocument);
        m_currentCultist.SetWalkTarget(m_cultistGoalWalkPoint, true);
        if(m_currentCultist.Acceptable) {
            Debug.Log("Cultist accepted: you win");
        }
        else {
            Debug.Log("Cultist accepted: you lose");
        }
    }

    public void DeclineCultist() {
        if (m_currentCultist.Acceptable) {
            Debug.Log("Cultist denied: you lose");
        }
        else {
            Debug.Log("Cultist denied: you win");
        }
        Destroy(m_currentCultist.gameObject);
        Destroy(m_spawnedDocument);
        SpawnCultist();
    }
}
