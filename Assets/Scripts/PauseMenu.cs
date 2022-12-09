using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseUI;
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
