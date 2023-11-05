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
    [SerializeField] Light pointlight;
    float defaultlightintensity;
    private Cultist m_currentCultist;
    public float cultistMoveSpeed = 3;
    public float cultistTurnSpeed = 2;
    private List<GameObject> m_spawnedDocuments = new List<GameObject>();
    private Player m_player;

    public bool IsCultistAtTable = false;

    private void Start() {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SpawnCultist();
        defaultlightintensity = pointlight.intensity;
        cultistfire.Stop();
    }

    public void SpawnCultist() {
        if (GameManager.Instance.IsDayEnded) {
            return;
        }
        if (GameManager.Instance.IsGameLost) {
            return;
        }
        GameManager.Instance.CurrentCultistIndex++;
        m_currentCultist = Instantiate(m_cultistBase, m_cultistSpawnPoint).GetComponent<Cultist>();
        m_currentCultist.SetWalkTarget(m_cultistWalkPoint);
        m_currentCultist.Init(m_cultistModel);
        pointlight.intensity = defaultlightintensity;
        UIManager.Instance.UpdateCultistText();
    }

    public void CultistAtTable() {
        Transform documentSpawn = m_documentSpawns[1];
        m_spawnedDocuments.Add(Instantiate(m_documentPrefab[0], documentSpawn.transform.position + Vector3.up, m_documentPrefab[0].transform.rotation, documentSpawn));
        m_spawnedDocuments[m_spawnedDocuments.Count - 1].GetComponent<Interactable>().SetText(m_currentCultist.CultistInfo);

        documentSpawn = m_documentSpawns[2];
        m_spawnedDocuments.Add(Instantiate(m_documentPrefab[1], documentSpawn.transform.position + Vector3.up, m_documentPrefab[1].transform.rotation, documentSpawn));
        StartCoroutine(SpawnDocumentsCoroutine());

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

    private IEnumerator SpawnDocumentsCoroutine() {
        while (m_spawnedDocuments[0].transform.localPosition.y > 0) {
            foreach (var item in m_spawnedDocuments) {
                float step = Vector3.up.y * Time.deltaTime * 2;
                if(item.transform.localPosition.y - step < 0) {
                    step = item.transform.localPosition.y;
                }
                item.transform.position -= Vector3.up * step;
                yield return null;
            }
        }
        IsCultistAtTable = true;
    }

    public void AcceptCultist() {
        if (!IsCultistAtTable) {
            return;
        }
        StartCoroutine(AcceptCoroutine());
        IsCultistAtTable = false;
    }
    public void DeclineCultist() {
        if (!IsCultistAtTable) {
            return;
        }
        StartCoroutine(DeclineCoroutine());
        IsCultistAtTable = false;
    }

    private IEnumerator AcceptCoroutine() {
        GameManager.Instance.TotalRecruited++;
        yield return DelayDestroy(1);
        foreach (var item in m_spawnedDocuments) {
            Destroy(item);
        }
        m_spawnedDocuments.Clear();
        m_currentCultist.SetWalkTarget(m_cultistGoalWalkPoint, true);
        if (m_currentCultist.Acceptable) {
            Debug.Log("Cultist accepted: you win");
            GameManager.Instance.BelieverRecruit++;
            //m_player.UpdateSanity(1);
        }
        else {
            Debug.Log("Cultist accepted: you lose");
            m_player.UpdateSanity(-1);
            GameManager.Instance.HereticRecruit++;
        }
        GameManager.Instance.CheckEndDay();
    }

    private IEnumerator DeclineCoroutine() {
        GameManager.Instance.TotalBurned++;
        if (m_currentCultist.Acceptable) {
            Debug.Log("Cultist denied: you lose");
            m_player.UpdateSanity(-1);
            GameManager.Instance.BelieverBurn++;
        }
        else {
            Debug.Log("Cultist denied: you win");
            GameManager.Instance.HereticBurn++;
            //m_player.UpdateSanity(1);
        }
        cultistfire.Play();
        pointlight.intensity = 0;
        yield return DelayDestroy(5);
        Destroy(m_currentCultist.gameObject);
        cultistfire.Stop();
        GameManager.Instance.CheckEndDay();
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
