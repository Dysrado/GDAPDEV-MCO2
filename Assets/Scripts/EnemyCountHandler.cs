using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EnemyCountHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private int maxKills;
    [SerializeField] private int currentKills;
    [SerializeField] private int maxKillsA1;
    [SerializeField] private int maxKillsA2;
    // Start is called before the first frame update
    void Start()
    {
        
        updateGoal(1);
        killText.text = currentKills.ToString() + "/" + maxKills.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        killText.text = currentKills.ToString() + "/" + maxKills.ToString();
    }

    public void addKills()
    {
        currentKills += 1;
    }

    public void updateGoal(int level)
    {
        switch (level)
        {
            case 1:
                currentKills = 0;
                maxKills = maxKillsA1;
                break;
            case 2:
                currentKills = 0;
                maxKills = maxKillsA2;
                break;
            case 3:
                currentKills = 0;
                maxKills = 1;
                break;
        }
    }
    public bool goalKills()
    {
        if (currentKills >= maxKills)
        {
            return true;
        }
        return false;
    }

    public void UltKills(int kills) {
        currentKills += kills;
    }

}
