using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionSystemPanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    public void ShowPanel()
    {
        Panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
}
