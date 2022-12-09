using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] GameObject levelSelect;

    public void LevelSelect()
    {
        levelSelect.SetActive(true);
    }

    public void Return()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenDebug()
    {
        this.gameObject.SetActive(true);
    }
}
