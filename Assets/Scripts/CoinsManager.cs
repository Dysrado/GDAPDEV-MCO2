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


}
