using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationaryEnemy : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] string WorldSpaceCanvas = "WorldSpace";
    [SerializeField] GameObject UITimer;
    private Image timerBar;
    Transform player;

    [SerializeField] float attackInterval = 1f;
    float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        timerBar = Instantiate(UITimer, GameObject.FindGameObjectWithTag(WorldSpaceCanvas).transform).GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Transform>();
        attackTime = attackInterval;
        timerBar.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (timerBar.gameObject != null)
        {
            timerBar.gameObject.SetActive(false);
        } 
    }


    // Update is called once per frame
    void Update()
    {
        UpdateBarPosition();
        UpdateTimer();
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        transform.right = player.transform.position - transform.position;
    }

    void UpdateBarPosition()
    {
        timerBar.transform.position = transform.position + new Vector3(0, 1, 0);
        timerBar.transform.forward = player.transform.position - timerBar.transform.position;
    }

    void UpdateTimer()
    {
        if (attackTime <= 0f)
        {
            Shoot();
            attackTime = attackInterval;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
        timerBar.fillAmount = attackTime / attackInterval;
    }

    void Shoot()
    {
        //Debug.Log($"Shoot by: {this.gameObject.name}");
    }
}
