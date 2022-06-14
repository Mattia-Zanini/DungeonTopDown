using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;
    [Header("File Storage Config")]
    [SerializeField] private string fileaName;
    [SerializeField] private bool useEncryption;
    private GameData gameData;
    private List<IDataManager> dataObjects;
    private FileDataHandler dataHandler;

    //public get, but private set
    public static DataManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one DataManager in this scene. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileaName, useEncryption);
    }
    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded Called");
        this.dataObjects = FindAllData();
        LoadGame();
    }
    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("OnSceneUnloaded Called");
        SaveGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null && this.initializeDataIfNull)
            NewGame();
        if (this.gameData == null)
        {
            Debug.Log("No data was found. A new game need to be started before data can be loaded.");
            return;
        }
        foreach (IDataManager dataObj in dataObjects)
        {
            dataObj.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found. A new game need to be started before data can be saved.");
            return;
        }
        foreach (IDataManager dataObj in dataObjects)
        {
            dataObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataManager> FindAllData()
    {
        IEnumerable<IDataManager> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataManager>();
        return new List<IDataManager>(dataObjects);
    }
    public bool HasGameData()
    {
        return this.gameData != null;
    }
}
