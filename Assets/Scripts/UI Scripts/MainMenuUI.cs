using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject HelpUI1;
    [SerializeField] private GameObject HelpUI2;

    // Start is called before the first frame update
    void Start()
    {
        HelpUI1.SetActive(false);
        HelpUI2.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneStrings.LEVEL_ONE_SCENE);
    }


    public void OpenHelpPanel1()
    {
        HelpUI1.SetActive(true);

    }
    public void OpenHelpPanel2()
    {
        HelpUI1.SetActive(false);
        HelpUI2.SetActive(true);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
