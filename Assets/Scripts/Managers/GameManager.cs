using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsDayEnded = false;

    public int MaxDays { get; private set; } = 3;
    public int MaxCultistPerDay { get; private set; } = 7;
    public int CurrentCultistIndex = 0;

    public bool IsGameLost = false;

    public int DayCount { get; private set; } = 1;

    public int TotalRecruited = 0;
    public int TotalBurned = 0;

    public int BelieverRecruit = 0;
    public int BelieverBurn = 0;

    public int HereticRecruit = 0;
    public int HereticBurn = 0;

    public void EndGame() {
        IsGameLost = true;
        UIManager.Instance.EndGame();
    }

    public void StartDay() {
        FindObjectOfType<Player>().UpdateSanity(1);
        DayCount++;
        IsDayEnded = false;
        ResetInfos();
        StartCoroutine(InfoCanvasManager.Instance.FadeOutCoroutine());
        CultistManager.Instance.SpawnCultist();
    }

    public void CheckEndDay() {
        if (CurrentCultistIndex == MaxCultistPerDay) {
            EndDay();
        }
    }

    public void EndDay() {
        IsDayEnded = true;
        InfoCanvasManager.Instance.UpdateInfos();
        StartCoroutine(InfoCanvasManager.Instance.FadeInCoroutine());
    }

    private void ResetInfos() {
        BelieverRecruit = 0;
        BelieverBurn = 0;
        HereticBurn = 0;
        HereticRecruit = 0;
        CurrentCultistIndex = 0;
    }
}
