using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Services.Authentication;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance { get; private set; }

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private void Awake()
    {
        if(instance != null )
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
        
        LeaderboadHandler leaderboadHandler = FindAnyObjectByType<LeaderboadHandler>();
        if( leaderboadHandler != null && AuthenticationService.Instance.IsSignedIn) 
        {
            leaderboadHandler.AddScore(gameData.highestScore);
        }
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if(gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults");
            NewGame();
        }

        foreach(IDataPersistence p in dataPersistenceObjects)
        {
            p.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach(IDataPersistence p in dataPersistenceObjects)
        {
            p.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    public GameData GetGameData() { return gameData; }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
