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
        Counting,
        Tutorial
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
        //TutorialText.text = ("lol");
        SpawnWave(waves[1]);
        //starts tutorial, sets the state to tutorial

        waveCountdown = timeBetweenWaves;
    }

    // only have code on start tutorial button, and end tutorial button
    void Update()
    {
        //if (state == SpawnState.Tutorial)
        //{
            //check if bool is true or false
            //if true, start the game normally
            //if false, reterernrnrn
            //If (dialogueNumber !== -1 && not [greatest number])
        //{
             //switch (dialogueNumber)
    //     {
    //         case 0:
            GetComponent<UnityEngine.UI.Text>().text = 
    //             Welcome to Empire of KingZ
    //         case 1:
                    
    //             This game is a wave defense game, the goal is to defend your castle from being conquered
    //             by the dark forces
    //         case 2:
            //         "My name is Haon and i am here to help you learn how to play this game"
            //    case 3:
            //         "If you look at the middle of your screen, you will see a castle, defend that at all costs"
            //    case 4:
            //         "Take a look at what happens if you press the houses to the top left of your screen"
            //    case 5:
            //         "Look! a grid popped up inside the castle, those squares represent where you can put down building, but beware not to put too much, as they all cost gold"
            //    case 6:
            //         "Speaking of gold, you are going to need it for practically everything within the game, whether that be troops, buildings, upgrades, and more."
            //    case 7:
            //         "Take a look at the houses, they are different in color and shape. The straw house, or the yellowish one is the one that grants you money, however, they can only be placed in the yellow colored tiles"
            //    case 8: 
            //         "If you look at the next house, the blue one, or the military house, this one give you troop spaces, each troop takes up a number of spaces and you can buy these houses to increase the maximum amount of troops you can put down. These houses are only places in the blue tiles"
            //    case 9:
            //         "With troops, you can find them on the bottom right side of your screen. If you open up the troop menu, you will find a varity of troops. The Hero, is determined by which civilization you chose at the beginning of the game, dont worry however as you can always change this later on in the game."
            //    case 10:
            //         "Be careful not to put down too many troops, as they cost both money and troop spaces. You can stop putting down the troops with the Q key."
            //    case 11: 
            //         "on the bottom left corner of your screen, you will see the upgrades menu. Here you can upgrade your heroes damage, health, speed and even base health."
            //    case 12:
            //         "If you look above the upgrades menu, you will see a slider bar. This here will help you progress faster as it will speed up the game, this can go as slow as 0x speed, which would pause the game, and as fast as 10x the speed of the game."
            //    case 13:
            //         "After this tutorial has ended, the enemies will spawn soon, make sure to defend them well as if you even let one slip through, it could ruin your entire empire. Enemies appear in waves,each one increasing in difficulty."
            //    case 14:
            //         "one thing to know about enemies is that they can damage both your base, and your troops.Some enemies only target one specific type, but most target both. Beware after 10 waves as there will be a strong monster called a boss, A boss is significantly stronger than normall enemies so make sure you have proper defenses set up."
            //    case 15:
            //         "In the later waves, there will be mini bosses every 5 waves, and a boss every 10. make sure to be geared up because enemies will get very difficult after a certain wave."
            //    case 16:
            //         "The goal is to defend for 100 waves of enemies, and succesfully defend your base from the dark forces, go ahead and have fun trying to win against them. If you need tips and tricks or a review on how to play this game, click on me and i'll gladly help."
            //    case 17:
            //         "This marks the end of this tutorial, so make sure to defend your empire with all you got, okay? Watch out because as soon as you click off of this, the enemies will start spawning in 20 seconds. You would want to start with a straw house by the way, Good Luck!"  
    //         default:
    //             return;
    //     }
    //      }
        //} 




        //bool tutorialComplete()
        //{
            //check if last speech bubble has been pressed, otherwise dont start the game
            //waveCountdown = timeBetweenWaves;
        //}




    //     public void SkipTutorial(int num)
    // {
    //    
    // }
        if (state == SpawnState.Waiting)
        {
            
            if (!EnemyIsAlive())
            {
                print("No enemies alive");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        
        else if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
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
 
        print( waveCountdown); 
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
        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}