using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsGameLost = false;

    public void EndGame() {
        IsGameLost = true;
        UIManager.Instance.EndGame();
    }
}
