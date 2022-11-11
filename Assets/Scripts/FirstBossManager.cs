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
    [SerializeField] private GameObject projectileSpawner;
    [SerializeField] private GameObject projectilePrefab;

    public GameObject shield;

    public float projectileSpeed;
    private float projectileTicks;
    private float projectileInterval;
    public float projectileMaxInterval;
    public List<GameObject> projectiles;
    public GameObject projectile;


    [SerializeField] private GameObject playerCenter;

    // Start is called before the first frame update
    void Start()
    {
        bossState = FirstBossState.SHIELDED;
        SpawnShield();
        SpawnProjectile();
        projectileTicks = 0f;
        projectileInterval = 3; // Default value
    }

    // Update is called once per frame
    void Update()
    {
        projectileTicks += Time.deltaTime;
        if(projectileTicks > projectileInterval)
        {
            SpawnProjectile();
            projectileTicks = 0f;
            projectileInterval = Random.Range(3, projectileMaxInterval + 1);
        }
        UpdateProjectiles();
    }

    public void SpawnShield()
    {
        shield = GameObject.Instantiate(shieldPrefab, shieldSpawner.transform);
    }

    public void SpawnProjectile()
    {
        projectile = GameObject.Instantiate(projectilePrefab, projectileSpawner.transform);
        projectiles.Add(projectile);

    }

    public void UpdateProjectiles()
    {
        for(int i = 0; i < projectiles.Count; i++)
        {
            //projectiles[i].transform.position = Vector3.MoveTowards(projectiles[i].transform.position, playerCenter.transform.position, projectileSpeed * Time.deltaTime);
        }
    }
}
