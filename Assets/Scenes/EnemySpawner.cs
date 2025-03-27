using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState
    {
        Spawning,
        Waiting,
        Counting
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public List<GameObject> enemies;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public bool tutorialComplete;
    public int dialogueNumber;
    public Text tutorialText;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 6f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    // Start is called before the first frame update
    void Start()
    {
        //Tutorial();;
        //starts tutorial, sets the state to tutorial
        
    }

    // only have code on start tutorial button, and end tutorial button
    void Update()
    {
        
        if (GameManager.Instance.TutorialOn == false)
        {
                SpawnWave(waves[1]);   
        };

        if (state == SpawnState.Waiting)
        {
            
            if (!EnemyIsAlive())
            {
                //print("No enemies alive");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        
        else if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning && GameManager.Instance.TutorialOn == false)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
           waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;
 
        //print( waveCountdown); 
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }



    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 6f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return true;
            }
        }
        return false;
    }



    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemies[Random.Range(0, _wave.enemies.Count)]);
            yield return new WaitForSeconds(5f);
        }
        state = SpawnState.Waiting;
        GameManager.Instance.wave++;
        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}