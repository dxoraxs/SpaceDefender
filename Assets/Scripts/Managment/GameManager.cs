using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private PlayerShip player;
    [SerializeField] private MainUI mainUi;
    [SerializeField] private UnityEvent onClickStartGame;
    [SerializeField] private UnityEvent OnEndGame;
    [SerializeField] private GameSettings gameSettings;
    private LevelConfig currentLevelType;
    private int currentIndextLevel;
    private SaveDataManager saveDataManager;

    public static GameSettings GetSettings => instance.gameSettings;
    public static int[] GetOpenLevel => instance.saveDataManager.GetOpenLevel;
    public static int[] GetCompleteLevel => instance.saveDataManager.GetCompleteLevel;
    public static PlayerShip GetShip => instance.player;

    public static void StartGame(int indexScene)
    {
        instance.onClickStartGame?.Invoke();
        instance.mainUi.HideStartPanel();
        instance.mainUi.ShowGamePanel();
        SelectLevel(indexScene);
        instance.enabled = true;
    }

    private static void SelectLevel(int indexScene)
    {
        instance.currentIndextLevel = indexScene;
        EventManager.UpdateUILevel?.Invoke(0);
        var currentLevel = GetSettings.GetLevel(indexScene);
        if (currentLevel.LevelType == LevelType.Asteroid)
            instance.currentLevelType = new AsteroidLevel(currentLevel, instance);
        else if (currentLevel.LevelType == LevelType.Time)
            instance.currentLevelType = new TimeLevel(currentLevel, instance);
    }

    public static void RestartLevel()
    {
        instance.currentLevelType = null;
        instance.mainUi.HideEndPanel();
        instance.mainUi.ShowGamePanel();
        AsteroidPool.ClearAsteroid();
        instance.player.StartHealth();
        instance.player.transform.position = Vector3.zero;
        StartGame(instance.currentIndextLevel);
    }

    public static void EndGame()
    {
        instance.mainUi.HideGamePanel();
        var endPanel = instance.mainUi.ShowEndPanel();
        instance.enabled = false;
        endPanel.InitEndPanel(true);
        instance.OnEndGame?.Invoke();

        instance.saveDataManager.SaveOpenLevel(instance.currentIndextLevel);
        instance.saveDataManager.SaveCompleteLevel(instance.currentIndextLevel);
        instance.saveDataManager.SaveData();

        SelectLevel(instance.currentIndextLevel + 1);
    }

    public static void PlayerDied()
    {
        instance.OnEndGame?.Invoke();
        instance.enabled = false;
        instance.mainUi.HideGamePanel();
        var endPanel = instance.mainUi.ShowEndPanel();
        endPanel.InitEndPanel(false);
    }

    private void Update()
    {
        if (currentLevelType != null)
        {
            currentLevelType.Update(Time.deltaTime);
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        saveDataManager = new SaveDataManager();

        if (!saveDataManager.IsFirstGameStar)
        {
            foreach (var level in gameSettings.GetAllLevel)
            {
                level.RandomizeLevel();
            }
        }
        saveDataManager.SaveData();
    }
}