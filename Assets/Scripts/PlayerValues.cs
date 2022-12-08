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
}
