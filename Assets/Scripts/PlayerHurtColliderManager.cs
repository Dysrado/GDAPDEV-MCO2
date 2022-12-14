using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtColliderManager : MonoBehaviour
{
    [SerializeField] private HPManager hpManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
        if(other.gameObject.CompareTag("GreenEnemy"))
        { 
            hpManager.dealDmg(1);
            other.gameObject.SetActive(false);
        }
    }

    public void Damage(int damage)
    {
        hpManager.dealDmg(damage);
    }
}
