using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenamePanelControl : MonoBehaviour, IDataPersistence
{
    [SerializeField] GameObject renamePanel;
    public void SaveData(ref GameData gameData)
    {
        gameData.firstTimeLogin = false;
    }

    public void LoadData(GameData gameData){}

    private void Start()
    {
        if (DataPersistenceManager.instance.GetGameData().firstTimeLogin)
        {
            renamePanel.SetActive(true);
            DataPersistenceManager.instance.SaveGame();
        }
        else
            renamePanel.SetActive(false);
    }

    public void ActivateRenamePanel()
    {
        renamePanel.SetActive(true);
    }
}
