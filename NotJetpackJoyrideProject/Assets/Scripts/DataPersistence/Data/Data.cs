using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int highestScore;
    public int coinCollected;
    public bool firstTimeLogin;

    public GameData()
    {
        highestScore = 0;
        coinCollected = 0;
        firstTimeLogin = true;
    }
}
