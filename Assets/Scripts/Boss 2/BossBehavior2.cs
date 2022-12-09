using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
public class BossBehavior2 : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    //[SerializeField] string WorldSpaceCanvas = "WorldSpace";
   // [SerializeField] GameObject UITimer;
    [SerializeField] int damageAmount = 2;
    //[SerializeField] Animator animator;
    [SerializeField] private GameObject[] shieldPrefab;
    [SerializeField] private GameObject objectCollider;
    //private Image timerBar;
    Transform player;
    HPManager hpManager;

    [SerializeField] float attackInterval = 4f;
    public float attackTime;

    [SerializeField] float teleportInterval = 0.5f;
    public float tpTime;

    [SerializeField] private GameObject[] NodePath;
    [SerializeField] private int shieldNumber = 0;
    private bool finishedShields = false;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider.SetActive(false);
        //timerBar = Instantiate(UITimer, GameObject.FindGameObjectWithTag(WorldSpaceCanvas).transform).GetComponent<Image>();
        hpManager = FindObjectOfType<HPManager>();
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Transform>();
        attackTime = attackInterval;
      //  timerBar.gameObject.SetActive(true);
        tpTime = teleportInterval;
    }

    private void OnEnable()
    {
        attackTime = attackInterval;
        tpTime = teleportInterval;
        //timerBar.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        //if (timerBar.gameObject != null)
        //{
        //    timerBar.gameObject.SetActive(false);
        //}
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
        //timerBar.transform.position = transform.position + new Vector3(0, 1, 0);
        //timerBar.transform.forward = player.transform.position - timerBar.transform.position;
    }

    void UpdateTimer()
    {
        if (attackTime <= 0f)
        {
            Attack();
            attackTime = attackInterval;
        }
        if (tpTime <= 0f){
            UpdatePosition();
            tpTime = teleportInterval;
        }
        else
        {
            attackTime -= Time.deltaTime;
            tpTime -= Time.deltaTime;
        }
       // timerBar.fillAmount = attackTime / attackInterval;
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
        hpManager.dealDmg(damageAmount);
    }

    public void shields() { 
        if (shieldNumber > 0 )
        {
            shieldNumber--;
            attackTime = attackInterval;
        }

        if (shieldNumber == 0)
        {
            objectCollider.SetActive(true);
        }
    }

    void UpdatePosition()
    {
        int set = Random.Range(0, NodePath.Length);
        this.transform.SetPositionAndRotation(NodePath[set].transform.position, Quaternion.identity);
        if (shieldNumber < 8 && !finishedShields)
        {
            generateShield();
            shieldNumber++;
        }
        if (shieldNumber >= 8)
        {
            finishedShields = true;
        }
    }

    void generateShield()
    {
        int type = Random.Range(0, 2);
        GameObject shield = Instantiate(shieldPrefab[type], new Vector3(this.transform.position.x + (shieldNumber * 0.5f), this.transform.position.y, this.transform.position.z), Quaternion.identity);
        shield.transform.parent = this.transform;
    }
}
