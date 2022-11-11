using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMode : MonoBehaviour
{
    [SerializeField] GameObject Panel;
   
    public void ShowPanel()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }
}
