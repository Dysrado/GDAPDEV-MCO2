using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Boss3Behavior : MonoBehaviour
{
    enum BossState
    {
        NORMAL = 0,
        ENRAGED,
        DOWNED,
        CHARGING
    };

    [SerializeField] Animator animator;

    [SerializeField] Transform[] projectileSpawnPoints;
    [SerializeField] GameObject[] projectilePrefabs;

    [SerializeField] float chargeTime = 5f; // how long it takes to charge the base attack
    float chargeTimer;
    bool startChargeTimer;

    int hitCount = 0; // number of times projectile groups have been destroyed

    bool startFight = false;
    BossState currentState = BossState.NORMAL;
    float stateInterval = 7.0f;
    float stateTimer;

    public List<GameObject> projectileList;

    // Start is called before the first frame update
    void Start()
    {
        chargeTimer = chargeTime;
        stateTimer = stateInterval;
        startChargeTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }


    void CheckState()
    {
        if (hitCount < 3)
        {

            if (stateTimer <= 0f)
            {
                startChargeTimer = true;
            }
            else
            {
                currentState = BossState.NORMAL;
                stateTimer -= Time.deltaTime;
            }
            

            if (startChargeTimer) // Start Charging
            {
                if (chargeTimer <= 0f) // attack
                {
                    stateTimer = stateInterval;
                    animator.SetTrigger("Attack");
                    animator.SetBool("IsCharging", false);
                    for (int i = 0; i < projectileList.Count; i++)
                    {
                        projectileList[i].GetComponent<Boss3Projectile>().Attack();
                    }
                    projectileList.Clear();
                    startChargeTimer = false;
                    chargeTimer = chargeTime;
                }
                else // charge
                {
                    if (projectileList.Count < 3)
                    {
                        int randomProjectile = Random.Range(0, projectilePrefabs.Length);
                        int randomLocation = Random.Range(0, projectileSpawnPoints.Length);
                        GameObject newProjectile = Instantiate(projectilePrefabs[randomProjectile], projectileSpawnPoints[randomLocation].position, Quaternion.identity, this.transform);
                        projectileList.Add(newProjectile);
                        animator.SetBool("IsCharging", true);
                    }

                    if (GetDisabled() <= 0) // if the projectiles are destroyed
                    {
                        animator.SetTrigger("Hit");
                        animator.SetBool("IsCharging", false);
                        hitCount++;
                        stateTimer = stateInterval;
                        projectileList.Clear();
                        startChargeTimer = false;
                        chargeTimer = chargeTime;
                        currentState = BossState.NORMAL;
                    }
                    
                    chargeTimer -= Time.deltaTime; 
                }
                currentState = BossState.CHARGING;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startFight = true;
        }
    }

    int GetDisabled()
    {
        int returnVal = 0;
        for (int i = 0; i < projectileList.Count; i++)
        {
            if (projectileList[i].activeInHierarchy)
            {
                returnVal++;
            }
        }
        return returnVal;
    }
}
