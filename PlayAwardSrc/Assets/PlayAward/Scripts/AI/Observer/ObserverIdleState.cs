using UnityEngine;
using System.Collections;

public class ObserverIdleState : EnemiesBaseState
{

    public override void BeginState()
    {
        if (myAnimator)
        {
            myAnimator.Play("Idle");
        }
    }

    public override void EndState()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
