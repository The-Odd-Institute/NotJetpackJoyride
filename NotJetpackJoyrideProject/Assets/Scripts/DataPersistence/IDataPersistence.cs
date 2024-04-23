using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add this to save and load data
public interface IDataPersistence
{
    void LoadData(GameData gameData);
    void SaveData(ref GameData gameData);
}
