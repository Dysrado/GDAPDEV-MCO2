using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandlerMimic : MonoBehaviour
{
    public bool finishedDmg;
    [SerializeField] Animator animator;
    // Start is called before the first frame update

    public void triggerDie()
    {
        animator.SetTrigger("Die");
    }

    public void triggerAttack()
    {
        animator.SetTrigger("Attack");
    }
    void Start()
    {

        finishedDmg = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageFinished()
    {
        finishedDmg = true;

    }
    public bool isDamageFinished()
    {
        return finishedDmg;
    }
    public void setDamageFinished(bool value)
    {
        finishedDmg = value;
    }
}
