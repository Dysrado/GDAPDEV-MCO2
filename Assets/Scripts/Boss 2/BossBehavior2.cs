using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class BossBehavior2 : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] int damageAmount = 2;
    [SerializeField] private GameObject[] shieldPrefab;
    [SerializeField] private GameObject objectCollider;
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
        hpManager = FindObjectOfType<HPManager>();
        player = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Transform>();
        attackTime = attackInterval;
        tpTime = teleportInterval;
        UpdatePosition();
        generateShield();
    }

    private void OnEnable()
    {
        attackTime = attackInterval;
        tpTime = teleportInterval;
    }

    


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
       LookAtPlayer();
        shields();
        if (FindObjectOfType<AnimationHandlerMimic>().isDamageFinished())
        {
            FindObjectOfType<LocalValues>().GetValues();
            SceneManager.LoadScene(SceneStrings.LEVEL_THREE_SCENE);
        }

    }

    void LookAtPlayer()
    {
        transform.right = player.transform.position - transform.position;
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
    }

    void Attack()
    {
        FindObjectOfType<AnimationHandlerMimic>().triggerAttack();
        hpManager.dealDmg(damageAmount);
    }

    public void shields() { 
        if (shieldNumber > 0)
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
        
       
    }

    void generateShield()
    {
       
        for (int i = 0; i < 8; i++)
        {
            int type = Random.Range(0, 2);
            GameObject shield = Instantiate(shieldPrefab[type], new Vector3(this.transform.position.x + (i * 0.5f), this.transform.position.y, this.transform.position.z), Quaternion.identity);
            shield.transform.parent = this.transform;

        }
        shieldNumber = 8;
        finishedShields = true;
       
    }
}
