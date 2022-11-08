using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RevolverGun : MonoBehaviour
{
    [SerializeField] string enemyTag = "BlueEnemy";
    [SerializeField] TMP_Text ammoText;

    // For the Magazine Size
    [SerializeField] float maxMagazineSize = 6;
    float currentAmmo;

    // For the interval between shots
    [SerializeField] float shotInterval = 0.3f;
    float shotTimer;

    // For the reload time
    [SerializeField] float reloadInterval = 2f;
    float reloadTimer;

    GameObject hitObj = null;
    bool canShoot = true;
    bool startShotInterval = false;
    bool isReloading = false;

    void Start()
    {
        //GestureManager.Instance.OnTap += OnTap;

        currentAmmo = maxMagazineSize;
        shotTimer = shotInterval;
        reloadTimer = reloadInterval;
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

    //public void OnTap(object sender, TapEventArgs e)
    //{
    //
    //}

    public void Reload()
    {
        if (!isReloading && currentAmmo != maxMagazineSize)
        {
            isReloading = true;
            Debug.Log("Reloading");
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
                Debug.Log(currentAmmo);
            }

            RaycastHit hit;
            //Debug.DrawRay(transform.position, transform.forward * 10, Color.red, 5);
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                hitObj = hit.collider.gameObject;
                if (hitObj.CompareTag(enemyTag))
                {
                    hitObj.SetActive(false);
                }
                else
                {
                    hitObj = null;
                }
            }
            startShotInterval = true;
        }
    }
}
