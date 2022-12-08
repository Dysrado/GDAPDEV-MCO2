using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Projectile : MonoBehaviour
{
    //[SerializeField] GameObject particle;
    Vector3 scale = Vector3.zero;

    [SerializeField] Vector3 finalSize;
    [SerializeField] float growthRate = .5f;
    [SerializeField] float speed = 10f;

    Transform playerPosition;

    bool isAttacking;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isAttacking = false;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= finalSize.x)
        {
            scale.x += growthRate * Time.deltaTime;
            scale.y += growthRate * Time.deltaTime;
            scale.z += growthRate * Time.deltaTime;
            this.transform.localScale = scale;
        }

        if (isAttacking)
        {
            rb.AddForce((playerPosition.position - transform.position).normalized * speed, ForceMode.Force);
        }

    }

    public void Attack()
    {
        isAttacking = true;
    }
}
