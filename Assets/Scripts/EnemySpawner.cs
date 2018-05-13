using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public bool spawning;
    public float initYPos;
    public int enemyPerRowCount;
    public int enemyRowCount;
    public float rowWidth;
    public float columnHeight;

    public GameObject enemy;
    public List<GameObject> currentEnemies;

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
        currentEnemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && spawning)
        {
            SpawnEnemies();
        }
	}

    public void SpawnEnemies()
    {
        float yPos = initYPos;

        for (int i = 0; i < enemyRowCount; i++)
        {
            SpawnEnemyRow(yPos);
            yPos += columnHeight / enemyRowCount;
        }
    }

    public void SpawnEnemyRow(float yPos)
    {
        for (int i = 0; i < enemyPerRowCount / 2 + 1; i++)
        {
            GameObject temp = Instantiate(enemy, new Vector3(i * (rowWidth / enemyPerRowCount), yPos, 0), enemy.transform.rotation);
            currentEnemies.Add(temp);
        }

        for (int i = 1; i < enemyPerRowCount / 2 + 1; i++)
        {
            GameObject temp = Instantiate(enemy, new Vector3(-(i *(rowWidth / enemyPerRowCount)), yPos, 0), enemy.transform.rotation);
            currentEnemies.Add(temp);
        }
    }

    public void ClearCurrentEnemies()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Enemy>().Die();
        }
    }
}
