using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaCollisionHandler : MonoBehaviour
{
    [SerializeField] private Collider boxCollider;
    [SerializeField] private CoinsManager coinsManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding!");
        if (collision.gameObject.CompareTag("GreenEnemy"))
        {
            collision.gameObject.SetActive(false);
            coinsManager.addCoin(2);
        }
    }
}
