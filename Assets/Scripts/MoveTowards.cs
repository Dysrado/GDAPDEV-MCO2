using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private string targetTag;
    [SerializeField] private float speed;
     
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        speed = Random.Range(speed, speed + 4f); // randomize speed
    }

    

    // Update is called once per frame
    void Update()
    {
        LookTowardsTarget();
        MoveTowardsTarget();
    }

    public void LookTowardsTarget()
    {
        transform.right = target.transform.position - transform.position;
    }

    public void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
