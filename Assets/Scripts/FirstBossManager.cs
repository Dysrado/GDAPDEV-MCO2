using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FirstBossState
{
    SHIELDED,
    VULNERABLE
}

public enum ShieldType
{
    RED,
    BLUE
}

public class FirstBossManager : MonoBehaviour
{
    public FirstBossState bossState;
    [SerializeField] private GameObject shieldSpawner;
    [SerializeField] private GameObject shieldPrefab;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        bossState = FirstBossState.SHIELDED;
        SpawnShield();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnShield()
    {
        shield = GameObject.Instantiate(shieldPrefab, shieldSpawner.transform);
    }
}
