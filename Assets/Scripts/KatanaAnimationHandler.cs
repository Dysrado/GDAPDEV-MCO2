using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("didSwipeLeft");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("didSwipeRight");
        }
    }

   
}
