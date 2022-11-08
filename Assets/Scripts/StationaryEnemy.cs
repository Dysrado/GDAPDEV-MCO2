using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationaryEnemy : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] string WorldSpaceCanvas = "WorldSpace";
    [SerializeField] GameObject UITimer;
    protected Image timerBar;
    Transform player;

    [SerializeField] float attackInterval = 1f;
    float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        timerBar = Instantiate(UITimer, GameObject.FindGameObjectWithTag(WorldSpaceCanvas).transform).GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Transform>();
        attackTime = attackInterval;
        
    }

    private void OnDestroy()
    {
        Destroy(timerBar);
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
        timerBar.transform.eulerAngles = player.rotation.eulerAngles + new Vector3(0,-90,0);
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
