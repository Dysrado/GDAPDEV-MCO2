using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private int currentCoins;

    // Start is called before the first frame update
    void Start()
    {
        currentCoins = 5;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = currentCoins.ToString();    
    }

    public void addCoin(int amt)
    {
        currentCoins += amt;
    }

    public int getCoins()
    {
        return currentCoins;
    }

    public void deductCoins(int amt)
    {
        currentCoins -= amt;
    }
}
