using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject LevelOne;
    [SerializeField] GameObject LevelTwo;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject[] LevelNodes;
    EnemySpawner spawnManager;
    private int currentLevel = 1;
    EnemyCountHandler killsManager;
    private bool transitionCondition;
    private bool finishTransition = false;

    [SerializeField] protected Image BurstMeter;
    [SerializeField] float burstTime = 15f;
    float burstTimer;
    bool canBurst = false;

    public float distanceThreshold = 1f;
    private Vector3 prevAccel = Vector3.zero;

    // Boss
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        killsManager = FindObjectOfType<EnemyCountHandler>();
        transitionSelect();
        burstTimer = burstTime;
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkPartClear();
        finishTransition = checkPosition();
        transitionMovement();

        if (prevAccel == Vector3.zero)
        {
            prevAccel = Input.acceleration;
        }

        float distance = Vector3.Distance(prevAccel, Input.acceleration);

        if (Mathf.Abs(distance) >= distanceThreshold)
        {
            if (canBurst) {
                Debug.Log("Burst");
                deleteEnemiesUlt();
                canBurst = false;
            }
        }

        prevAccel = Input.acceleration;
        if (!canBurst) {
            if (burstTimer <= 0)
            {
                canBurst = true;
                burstTimer = burstTime;
            }
            else
            {
                burstTimer -= Time.deltaTime;
            }
        }
        BurstMeter.fillAmount = burstTimer/burstTime;
    }

    void checkPartClear()
    {
        transitionCondition = killsManager.goalKills();
        if (transitionCondition)
        {
            if (currentLevel < 3)
            {
                currentLevel++;
                killsManager.updateGoal(currentLevel);
                Debug.Log("Transition..");  
                transitionSelect();
            }
        }
    }

    void transitionSelect()
    {

        switch (currentLevel)
        {
            case 1:
                LevelOne.SetActive(true);
                LevelTwo.SetActive(false);
                break;
            case 2:
                LevelOne.SetActive(false);
                LevelTwo.SetActive(true);
                break;
            case 3:
                LevelOne.SetActive(false);
                LevelTwo.SetActive(false);
                break;
        }
    }

    void transitionMovement()
    {
        if (!finishTransition)
        {
            switch (currentLevel)
            {
                case 1:
                    Player.transform.position = Vector3.MoveTowards(Player.transform.position, LevelNodes[0].transform.position, 4 * Time.deltaTime);
                    break;
                case 2:
                    Player.transform.position = Vector3.MoveTowards(Player.transform.position, LevelNodes[1].transform.position, 4 * Time.deltaTime);
                    break;
                case 3:
                    Player.transform.position = Vector3.MoveTowards(Player.transform.position, LevelNodes[2].transform.position, 4 * Time.deltaTime);
                    break;
            }
            deleteEnemies();
        }
    }

    bool checkPosition()
    {
        switch (currentLevel)
        {
            case 1:
                if (Player.transform.position == LevelNodes[0].transform.position)
                {
                    return true;
                }
                break;
            case 2:
                if (Player.transform.position == LevelNodes[1].transform.position)
                {
                    return true;
                }
                break;
            case 3:
                if (Player.transform.position == LevelNodes[2].transform.position)
                {
                    boss.SetActive(true);
                    return true;
                }
                break;
        }
        return false;
    }

    void deleteEnemies()
    {
        GameObject[] red = GameObject.FindGameObjectsWithTag("RedEnemy");
        GameObject[] green = GameObject.FindGameObjectsWithTag("GreenEnemy");
        GameObject[] blue = GameObject.FindGameObjectsWithTag("BlueEnemy");
        for (int i = 0; i < red.Length; i++)
        {
            red[i].SetActive(false);
        }
        for (int i = 0; i < green.Length; i++)
        {
            green[i].SetActive(false);
        }
        for (int i = 0; i < blue.Length; i++)
        {
            blue[i].SetActive(false);
        }

    }

    void deleteEnemiesUlt()
    {
        GameObject[] red = GameObject.FindGameObjectsWithTag("RedEnemy");
        GameObject[] green = GameObject.FindGameObjectsWithTag("GreenEnemy");
        GameObject[] blue = GameObject.FindGameObjectsWithTag("BlueEnemy");
        for (int i = 0; i < red.Length; i++)
        {
            red[i].SetActive(false);
        }
        for (int i = 0; i < green.Length; i++)
        {
            green[i].SetActive(false);
        }
        for (int i = 0; i < blue.Length; i++)
        {
            blue[i].SetActive(false);
        }
        int total = red.Length + green.Length + blue.Length;
        killsManager.UltKills(total);
    }
}
