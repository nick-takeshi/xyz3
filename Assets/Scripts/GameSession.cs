using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Diagnostics;

public class GameSession : MonoBehaviour
{
    [SerializeField] private PlayerData _data;
    [SerializeField] public string _defaultCheckPoint;

    public PlayerData Data => _data;
    private PlayerData _save;

    private readonly CompositeDisposable _trash = new CompositeDisposable();
    public QuickInventoryModel QuickInventory { get; private set; }
    public PerksModel PerksModel { get; private set; }
    public StatsModel StatsModel { get; private set; }
    public SkinModel SkinModel { get; private set; }

    public List<string> _checkpoints = new List<string>();

    private void Awake()
    {
        var existsSession = GetExistSession();

        if (existsSession != null)
        {
            existsSession.StartSession(_defaultCheckPoint);
            Destroy(gameObject);
        }
        else
        {
            Save();
            InitModels();
            DontDestroyOnLoad(this);
            StartSession(_defaultCheckPoint);
        }
    }

    private void StartSession(string defaultCheckPoint)
    {
        SetChecked(defaultCheckPoint);

        LoadHUD();
        SpawnHero();
    }

    private void SpawnHero()
    {
        var checkPoints = FindObjectsOfType<CheckPointComponent>();
        var lastCheckPoint = _checkpoints.Last();
        foreach (var checkPoint in checkPoints)
        {
            if (checkPoint.Id == lastCheckPoint)
            {
                checkPoint.SpawnHero();
                break;
            }
        }
    }

    private void InitModels()
    {
        QuickInventory = new QuickInventoryModel(_data);
        _trash.Retain(QuickInventory);

        PerksModel = new PerksModel(_data);
        _trash.Retain(PerksModel);

        StatsModel = new StatsModel(_data);
        _trash.Retain(StatsModel);

        SkinModel = new SkinModel(_data);
        _trash.Retain(SkinModel);


        _data.Hp.Value = (int)StatsModel.GetValue(StatId.Hp);
    }

    private void LoadHUD()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        OnScreenControls();

    }

    [Conditional("USE_ONSCREEN_CONTROLS")]
    private void OnScreenControls()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
    }

    private GameSession GetExistSession()
    {
        var sessions = FindObjectsOfType<GameSession>();

        foreach (var gameSession in sessions)
        {
            if (gameSession != this)
            {
                return gameSession;
            }
        }

        return null;
    }

    public void Save()
    {
        _save = _data.Clone();
    }

    public void LoadLastSave()
    {
        _data = _save.Clone();

        _trash.Dispose();
        InitModels();
    }

    private void OnDestroy()
    {
        _trash.Dispose();
    }

    public bool IsChecked(string id)
    {
        return _checkpoints.Contains(id);
    }

    public void SetChecked(string id)
    {
        if (!_checkpoints.Contains(id))
        {
            Save();

            _checkpoints.Add(id);
        }
    }

    public List<string> _removedItems = new List<string>();

    public bool RestoreState(string itemId)
    {
        return _removedItems.Contains(itemId);
    }

    public void StoreState(string itemId)
    {
        if (!_removedItems.Contains(itemId))
            _removedItems.Add(itemId);
    }
}




