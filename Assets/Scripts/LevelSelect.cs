using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Load1()
    {
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(SceneStrings.LEVEL_ONE_SCENE);
    }    

    public void Load2()
    {
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(SceneStrings.LEVEL_TWO_SCENE);
    }    
    
    public void Load3()
    {
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(SceneStrings.LEVEL_THREE_SCENE);
    }
}
