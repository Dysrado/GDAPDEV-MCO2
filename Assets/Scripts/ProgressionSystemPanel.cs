using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionSystemPanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    private void Start()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ShowPanel()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
