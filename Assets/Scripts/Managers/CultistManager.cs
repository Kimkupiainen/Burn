using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class CultistManager : Singleton<CultistManager>
{
    [SerializeField] GameObject m_cultistBase;
    [SerializeField] GameObject m_cultistModel;
    [SerializeField] GameObject[] m_documentPrefab;
    [SerializeField] private List<Transform> m_documentSpawns;
    [SerializeField] private Transform m_cultistSpawnPoint;
    [SerializeField] private Transform m_cultistWalkPoint;
    [SerializeField] private Transform m_cultistGoalWalkPoint;
    [SerializeField] VisualEffect cultistfire;
    private Cultist m_currentCultist;
    public float cultistMoveSpeed = 3;
    public float cultistTurnSpeed = 2;
    private List<GameObject> m_spawnedDocuments = new List<GameObject>();
    private Player m_player;

    private void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SpawnCultist();
        cultistfire.Stop();
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
        Transform documentSpawn = m_documentSpawns[1];
        m_spawnedDocuments.Add(Instantiate(m_documentPrefab[0], documentSpawn));
        m_spawnedDocuments[m_spawnedDocuments.Count - 1].GetComponent<Interactable>().SetText(m_currentCultist.CultistInfo);

        documentSpawn = m_documentSpawns[2];
        m_spawnedDocuments.Add(Instantiate(m_documentPrefab[1], documentSpawn)); 

        List<string> infos = m_currentCultist.CultistInfo.Split(",").ToList();
        string realInfos = "";
        for (int i = 0; i < infos.Count; i++) {
            if (i == 0 || i == infos.Count - 1) {
                realInfos += infos[i] + ",";
            }
        }
        realInfos = realInfos.Remove(realInfos.Length - 1);
        m_spawnedDocuments[m_spawnedDocuments.Count - 1].GetComponent<Interactable>().SetText(realInfos);
    }

    public void AcceptCultist() {
        StartCoroutine(AcceptCoroutine());
    }
    public void DeclineCultist() {
        StartCoroutine(DeclineCoroutine());
    }

    private IEnumerator AcceptCoroutine() {
        yield return DelayDestroy(1);
        foreach (var item in m_spawnedDocuments) {
            Destroy(item);
        }
        m_spawnedDocuments.Clear();
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
        cultistfire.Play();
        yield return DelayDestroy(5);
        Destroy(m_currentCultist.gameObject);
        cultistfire.Stop();
        SpawnCultist();

    }


    private IEnumerator DelayDestroy(float delayTime) {
        yield return new WaitForSeconds(delayTime);
        foreach (var item in m_spawnedDocuments) {
            Destroy(item);
        }
        m_spawnedDocuments.Clear();
    }
}
