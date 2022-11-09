using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnSwipe += OnSwipe;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnSwipe -= OnSwipe;
    }

    public void OnSwipe(object send, SwipeEventArgs args)
    {
        Debug.Log($"Swipe Detected, {args.SwipeDirection}");

        if (args.SwipeDirection == SwipeDirection.RIGHT)
        {
            animator.SetTrigger("didSwipeRight");
        }
        else if (args.SwipeDirection == SwipeDirection.LEFT)
        {
            animator.SetTrigger("didSwipeLeft");
        }
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
