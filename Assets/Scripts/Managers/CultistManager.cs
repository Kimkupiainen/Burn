using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistManager : Singleton<CultistManager>
{
    [SerializeField] GameObject m_cultistBase;
    [SerializeField] GameObject m_cultistModel;
    [SerializeField] GameObject[] m_documentPrefab;
    [SerializeField] private List<Transform> m_documentSpawns;
    [SerializeField] private Transform m_cultistSpawnPoint;
    [SerializeField] private Transform m_cultistWalkPoint;
    [SerializeField] private Transform m_cultistGoalWalkPoint;
    private Cultist m_currentCultist;
    public float cultistMoveSpeed = 3;
    public float cultistTurnSpeed = 2;
    private GameObject m_spawnedDocument;
    private Player m_player;

    private void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SpawnCultist();
    }

    public void SpawnCultist() {
        if (GameManager.Instance.IsGameLost) {
            return;
        }
        m_currentCultist = Instantiate(m_cultistBase, m_cultistSpawnPoint).GetComponent<Cultist>();
        m_currentCultist.SetWalkTarget(m_cultistWalkPoint);
        m_currentCultist.Init(m_cultistModel);
    }

    public void CultistAtTable() {
        Transform documentSpawn = m_documentSpawns[Random.Range(0, m_documentSpawns.Count)];
        m_spawnedDocument = Instantiate(m_documentPrefab[Random.Range(0, m_documentPrefab.Length)], documentSpawn);
        m_spawnedDocument.GetComponent<Interactable>().SetText(m_currentCultist.CultistInfo);
    }

    public void AcceptCultist() {
        StartCoroutine(AcceptCoroutine());
    }
    public void DeclineCultist() {
        StartCoroutine(DeclineCoroutine());
    }

    private IEnumerator AcceptCoroutine() {
        yield return DelayDestroy(1);
        Destroy(m_spawnedDocument);
        m_currentCultist.SetWalkTarget(m_cultistGoalWalkPoint, true);
        if (m_currentCultist.Acceptable) {
            Debug.Log("Cultist accepted: you win");
            //m_player.UpdateSanity(1);
        }
        else {
            Debug.Log("Cultist accepted: you lose");
            m_player.UpdateSanity(-1);
        }

    }

    private IEnumerator DeclineCoroutine() {
        if (m_currentCultist.Acceptable) {
            Debug.Log("Cultist denied: you lose");
            m_player.UpdateSanity(-1);
        }
        else {
            Debug.Log("Cultist denied: you win");
            //m_player.UpdateSanity(1);
        }
        yield return DelayDestroy(1);
        Destroy(m_currentCultist.gameObject);
        SpawnCultist();

    }


    private IEnumerator DelayDestroy(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        Destroy(m_spawnedDocument);
    }
}
