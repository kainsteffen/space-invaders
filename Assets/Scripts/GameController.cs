using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int gameScore;

    public GameObject player;
    public GameObject mainCamera;
    public GameObject enemySpawner;

    public Vector3 playerSpawnPos;

    private enum State
    {
        INGAME,
        GAMEOVER
    }

    private State gameState;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        gameState = State.INGAME;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (gameState)
        {
            case State.INGAME:

                if (!player.activeSelf)
                {
                    EndGame();
                }

                if (Input.GetKeyDown("n"))
                {
                    ResetGame();
                }

                break;

            case State.GAMEOVER:

                if (Input.GetKeyDown("n"))
                {
                    ResetGame();
                }

                break;
        }	
	}

    public void EndGame()
    {
        gameState = State.GAMEOVER;

        UIController.Instance.ShowGameOverTxt();
        EnemySpawner.Instance.ClearCurrentEnemies();
        EnemySpawner.Instance.spawning = false;
    }

    public void ResetGame()
    {
        gameState = State.INGAME;

        gameScore = 0;

        player.transform.position = playerSpawnPos;
        player.GetComponent<Player>().Revive();

        EnemySpawner.Instance.ClearCurrentEnemies();
        EnemySpawner.Instance.spawning = true;
        UIController.Instance.HideGameOverTxt();
    }

    public void IncreaseGameScore(int value)
    {
        gameScore += value;
    }
}
