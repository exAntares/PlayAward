using UnityEngine;
using System.Collections;

public class ChaserIdleState : EnemiesBaseState
{
	public bool StartChase = false;
	public bool bCanStartChasing = false;

	public override void BeginState()
	{
		StartChase = false;
		bCanStartChasing = false;
		if(myAnimator)
		{
			myAnimator.Play("Idle");
		}
	}
	
	public override void EndState()
	{
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Player && CanStartChasing() && !StartChase)
        {
            float Rotation = Quaternion.Dot(Player.transform.rotation, transform.rotation);
            if (Mathf.Abs(Rotation) <= 0.4f)
            {
				StartChasing();
            }
        }
	}

	public void DelayedStartChasing(float TimeToStart)
	{
		if(!enabled) return;

		Invoke("StartChasing", TimeToStart > 0 ? TimeToStart : 5.0f);
	}

	[ContextMenu("StartChasing")]
	public void StartChasing()
	{
		if(!enabled) return;

		StartChase = true;
		if(myAnimator)
		{
			myAnimator.Play("StartChasing");
		}

		Invoke("Internal_StartChasing", 2.0f);
	}

    void Internal_StartChasing()
    {
        if (!enabled) return;

        if(CanGoToState("Chasing"))
        {
            GoToState("Chasing");
        }
    }

	bool CanStartChasing()
	{
		if(!enabled) return false;

		return bCanStartChasing;
	}
}
