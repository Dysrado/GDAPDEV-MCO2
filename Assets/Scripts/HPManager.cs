using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HPManager : MonoBehaviour
{
    [SerializeField] CoinsManager coinsmanager;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHP.ToString();
    }

    public void dealDmg(int dmg)
    {
        currentHP -= dmg;
    }

    public void IncreaseHP()
    {
        if (maxHP < 15 && coinsmanager.getCoins() >= 3)
        {
            coinsmanager.deductCoins(3);
            maxHP++;
            currentHP = maxHP; 
        }
    }

    public void InfiniteHP()
    {
        maxHP = 9999;
        currentHP = maxHP;  
    }

    public void SetHP(int health)
    {
        maxHP = health;
    }
}
