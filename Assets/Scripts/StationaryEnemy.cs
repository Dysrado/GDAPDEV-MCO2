using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationaryEnemy : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] string WorldSpaceCanvas = "WorldSpace";
    [SerializeField] GameObject UITimer;
    [SerializeField] int damageAmount = 1;
    private Image timerBar;
    Transform player;
    HPManager hpManager;

    [SerializeField] float attackInterval = 1f;
    public float attackTime;
    // Start is called before the first frame update
    void Awake()
    {
        timerBar = Instantiate(UITimer, GameObject.FindGameObjectWithTag(WorldSpaceCanvas).transform).GetComponent<Image>();
        hpManager = FindObjectOfType<HPManager>();
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Transform>();
        attackTime = attackInterval;
        timerBar.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
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
        hpManager.dealDmg(damageAmount);
    }

    
}
