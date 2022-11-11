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
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject shieldSpawner;
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private GameObject projectileSpawner;
    [SerializeField] private GameObject projectilePrefab;

    public GameObject shield;
    public BossShieldManager bossShieldManager;

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
        // Projectiles
        projectileTicks += Time.deltaTime;
        if(projectileTicks > projectileInterval)
        {
            SpawnProjectile();
            projectileTicks = 0f;
            projectileInterval = Random.Range(3, projectileMaxInterval + 1);
        }
        UpdateProjectiles();

        // Shield
        UpdateShield();
    }

    public void SpawnShield()
    {
        shield = GameObject.Instantiate(shieldPrefab, shieldSpawner.transform);
        bossShieldManager = shield.GetComponent<BossShieldManager>();
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

    public void UpdateShield()
    {
        if (!bossShieldManager.IsChildrenActive())
        {
            Debug.Log("No more shields!");
        }
        else
        {
            animator.SetBool("isDamaged", false);
        }
    }
}
