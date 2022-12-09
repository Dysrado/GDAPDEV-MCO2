using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalValues : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int coins = 5;

    [SerializeField] float timeElapsed = 0;

    [SerializeField] float rifleMag = 30;
    [SerializeField] float revMag = 6;

    [SerializeField] float fireRateRev = 0.3f;



    // Call this on the start of the scene

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }
    private void Start()
     {
        // Take values from the singleton
        maxHealth = PlayerValues.Instance.GetHealth();
        coins = PlayerValues.Instance.GetCoins();

        timeElapsed = PlayerValues.Instance.GetTimeElapsed();

        rifleMag = PlayerValues.Instance.GetRifleMag();
        revMag = PlayerValues.Instance.GetRevolverMag();

        fireRateRev = PlayerValues.Instance.GetRevFireRate();


        
    }

    //Call this after the shop is closed
    public void disperse()
    {
        // Place new values into the other functions
        FindObjectOfType<HPManager>().SetHP(maxHealth);
        FindObjectOfType<CoinsManager>().SetCoins(coins);

        FindObjectOfType<RifleGun>().SetMag(rifleMag);
        FindObjectOfType<RevolverGun>().SetMag(revMag);

        FindObjectOfType<RevolverGun>().SetFireRate(fireRateRev);

    }

    // Use this function when the boss is killed
    public void GetValues()
    {
        // get the coins
        coins = FindObjectOfType<CoinsManager>().getCoins();

        // put the values into singleton
        PlayerValues.Instance.SetHealth(maxHealth);
        PlayerValues.Instance.SetCoins(coins);

        PlayerValues.Instance.SetTimeElapsed(timeElapsed);

        PlayerValues.Instance.SetRifleMag(rifleMag);
        PlayerValues.Instance.SetRevolverMag(revMag);

        PlayerValues.Instance.SetRevFireRate(fireRateRev);
    }

    // Shop Progression System
    public void addCoins(int coins) { this.coins += coins; }
    public void deductCoins(int coins) { this.coins -= coins; }
    public void addMaxHP()
    {
        if (maxHealth < 15 && coins >= 15)
        {
            this.maxHealth++;
            deductCoins(3);
        }
    }

    public void addRifleMag()
    {
        if (rifleMag < 60 && coins >= 20)
        {
            deductCoins(2);
            rifleMag += 15;
        }
    }

    public void addRevMag()
    {
        if (revMag < 12 && coins >= 20)
        {
            deductCoins(2);
            revMag++;
        }
    }

    public void addRevFireRate()
    {
        if (fireRateRev > 0.1f && coins >= 10)
        {
            deductCoins(1);
            fireRateRev -= 0.1f;
        }
    }
}
