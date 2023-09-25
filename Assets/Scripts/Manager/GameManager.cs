using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    None = 0,
    Playing = 1,
    GameOver = 2,
}

public class GameManager : Singleton<GameManager>
{
    private GameState gameState = GameState.None;
    private int hp = 0;
    public UnityAction<int> hpEvent;

    [Header("Insepctor")]
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private int spawnCount = 6;

    private void Awake()
    {
        Instance = this;
        isDontDestroyed = true;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        KeyInput();
    }

    private void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(gameState == GameState.Playing && Target.TargetCount() <= 0)
            {
                Spawn();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameState == GameState.GameOver)
            {
                StartGame();
            }
        }
    }

    #region HP

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int value)
    {
        if (value < 0)
            hp = 0;
        else
            hp = value;
        if(hpEvent != null)
            hpEvent.Invoke(hp);
        //if(UIManager.Exist())
        //    UIManager.Instance.SetHpText(hp);

        CheckHp();
    }

    public void AddHp(int value)
    {
        SetHp(GetHp() + value);
        CheckHp();
    }

    public void SubHp(int value)
    {
        SetHp(GetHp() - value);
        CheckHp();
    }

    public void CheckHp()
    {
        if( hp <= 0 )
        {
            GameOver();
        }
    }

    #endregion


    #region GameState
    public void StartGame()
    {
        SetHp(200);
        gameState = GameState.Playing;
        Spawn();
        UIManager.Instance.SetSystemMessage("");
    }

    public void GameOver()
    {
        SetGameState(GameState.GameOver);
        UIManager.Instance.SetSystemMessage("Press \"R\"\nto restart");
    }

    public void ResetGame()
    {
        StartGame();
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    #endregion

    #region Spawn

    public void Spawn()
    {
        if (UnitGroup.instance == null)
            return;

        UIManager.Instance.SetSystemMessage("");

        foreach(Transform trans in UnitGroup.instance)
        {
            Destroy(trans.gameObject);
        }
        for(int i = 0; i < spawnCount; i++)
        {
            Instantiate(targetPrefab, new Vector3(-5 + i * 2, 0, 0), Quaternion.identity, UnitGroup.instance);
        }
    }

    #endregion
}
