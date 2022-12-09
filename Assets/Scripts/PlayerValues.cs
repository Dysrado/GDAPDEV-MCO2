using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public static PlayerValues Instance;

    int health = 10;
    int coins = 5;

    float timeElapsed = 0;

    float rifleMag = 30;
    float revMag = 6;

    float fireRateRev = 0.3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Getters
    public int GetHealth() { return health; }
    public int GetCoins() { return coins; }
    public float GetTimeElapsed() { return timeElapsed; }
    public float GetRifleMag() { return rifleMag; }
    public float GetRevolverMag() { return revMag; }
    public float GetRevFireRate() { return fireRateRev; }

    // Setters
    public void SetHealth(int health) { this.health = health;  }
    public void SetCoins(int coins) { this.coins = coins;  }
    public void SetTimeElapsed(float timeElapsed) { this.timeElapsed = timeElapsed;  }
    public void SetRifleMag(float rifleMag) { this.rifleMag = rifleMag;  }
    public void SetRevolverMag(float revMag) { this.revMag = revMag;  }
    public void SetRevFireRate(float fireRate) { this.fireRateRev = fireRate;  }

    // Shop Progression System
    public void addCoins(int coins) { this.coins += coins; }
    public void deductCoins(int coins) { this.coins -= coins; }
    public void addMaxHP(int HP) {
        if (health < 15 && coins >= 3)
        {
            this.health += HP;
            deductCoins(3);
        }
    }

    public void addRifleMag(){
        if (rifleMag < 60 && coins >= 2)
        {
            deductCoins(2);
            rifleMag += 15;
        }
    }

    public void addRevMag()
    {
        if (revMag < 12 && coins >= 2)
        {
            deductCoins(2);
            revMag++;
        }
    }

    public void addRevFireRate()
    {
        if (fireRateRev > 0.1f && coins >= 1)
        {
            deductCoins(1);
            fireRateRev -= 0.1f;
        }
    }

}
