using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    ObjectPooler objPooler;
   
   
    [SerializeField] GameObject[] NodeList;
    [SerializeField] float SpawnInterval = 1.5f;
    private float Timer;
    void Start()
    {
        objPooler = ObjectPooler.Instance;
        Timer = SpawnInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Timer < 0f)
        {
            int Enemy = Random.Range(1, 3); //1 is Green, 2 is Blue, 3 is Red
            //int Enemy = 3;
            int Node;
            switch (Enemy)
            {
                case 1:
                    Node = Random.Range(1, 3);
                    objPooler.SpawnFromPool("GreenEnemy", NodeList[Node - 1].transform.position);
                    break;
                case 2:
                    Node = Random.Range(4, 6);
                    objPooler.SpawnFromPool("BlueEnemy", NodeList[Node - 1].transform.position);
                    break;
                case 3:
                    Node = Random.Range(7, 9);
                    objPooler.SpawnFromPool("RedEnemy", NodeList[Node - 1].transform.position);
                    break;
            }
                Timer = SpawnInterval;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }

    
}
