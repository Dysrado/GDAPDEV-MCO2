using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RifleGun : MonoBehaviour
{
    [SerializeField] string enemyTag = "BlueEnemy";
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Camera PlayerCam;
    [SerializeField] EnemyCountHandler killsManager;
    [SerializeField] AudioClip clip;
    // For the Magazine Size
    [SerializeField] float maxMagazineSize = 30;
    float currentAmmo;

    // For the interval between shots
    [SerializeField] float shotInterval = 0.1f;
    float shotTimer;

    // For the reload time
    [SerializeField] float reloadInterval = 2f;
    float reloadTimer;

    GameObject hitObj = null;
    bool canShoot = true;
    bool startShotInterval = false;
    bool isReloading = false;

    [SerializeField] Animator anim;

    //// For scoring
    [SerializeField] private CoinsManager coinsManager;

    [SerializeField] ParticleSystem muzzleFlash;

    void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
        muzzleFlash.Stop();

        currentAmmo = maxMagazineSize;
        shotTimer = shotInterval;
        reloadTimer = reloadInterval;

    }

    private void OnEnable()
    {
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) // countdownt for the reload
        {
            reloadTimer -= Time.deltaTime;
            canShoot = false;
            ammoText.text = "Reloading";
        }
        else
        {
            ammoText.text = currentAmmo.ToString();
        }

        if (startShotInterval) // countdown for the shots
        {
            shotTimer -= Time.deltaTime;
            canShoot = false;
        }

        if (shotTimer < 0f) // reset values when timer is done
        {
            startShotInterval = false;
            canShoot = true;
            shotTimer = shotInterval;
        }

        if (reloadTimer < 0f) // reset values when timer is done
        {
            reloadTimer = reloadInterval;
            currentAmmo = maxMagazineSize;
            isReloading = false;
            canShoot = true;
            Debug.Log("Reload Done");
        }

    }

    public void Reload()
    {
        if (!isReloading && currentAmmo != maxMagazineSize)
        {
            isReloading = true;
            anim.SetTrigger("RReload");
            Debug.Log("Reloading");
            SoundManager.Instance.PlaySound(clip);
        }
    }

    // Used for the button
    public void Shoot()
    {
        if (canShoot && !startShotInterval)
        {

            if (currentAmmo > 0)
            {
                currentAmmo--;
                muzzleFlash.Play();
                anim.SetTrigger("RShoot");
                SoundManager.Instance.PlaySound(clip);

                startShotInterval = true;

                RaycastHit hit;
                if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, Mathf.Infinity))
                {
                    hitObj = hit.collider.gameObject;
                    if (hitObj.CompareTag(enemyTag))
                    {
                        hitObj.SetActive(false);
                        coinsManager.addCoin(4);
                        killsManager.addKills();
                    }
                    else if (hitObj.CompareTag("BossRed"))
                    {
                        Debug.Log("Hit shieldR");
                        hitObj.SetActive(false);
                        BossBehavior2 boss = FindObjectOfType<BossBehavior2>();
                        boss.shields();
                    }
                    else if (hitObj.CompareTag("Boss"))
                    {
                        FindObjectOfType<AnimationHandlerMimic>().triggerDie();

                    }
                    else
                    {
                        hitObj = null;
                    }
                }
            }
        }
    }

    public void increaseMagSize()
    {
        if (maxMagazineSize < 60 && coinsManager.getCoins() >= 2)
        {
            Debug.Log("Bought stuff");
            coinsManager.deductCoins(2);    
            maxMagazineSize += 15;
        }
    }
    public void infiniteAmmo()
    {
        maxMagazineSize = 9999;
        currentAmmo = maxMagazineSize;
    }

    public void SetMag(float magSize)
    {
        maxMagazineSize = magSize;
    }
}
