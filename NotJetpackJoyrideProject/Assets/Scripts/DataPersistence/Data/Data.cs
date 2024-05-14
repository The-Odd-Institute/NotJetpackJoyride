using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int highestScore;
    public bool firstTimeLogin;

    public GameData()
    {
        highestScore = 0;
        firstTimeLogin = true;
    }
}
