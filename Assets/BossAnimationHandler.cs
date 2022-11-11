using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationHandler : MonoBehaviour
{
    public bool finishedDmg;

    // Start is called before the first frame update
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
