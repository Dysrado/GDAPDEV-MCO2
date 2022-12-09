using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] TMP_InputField input;


    public void Send()
    {
        FindObjectOfType<WebHandler>().CreatePlayer(input.text, FindObjectOfType<LocalValues>().GetTimeElapsed());
    }
}
