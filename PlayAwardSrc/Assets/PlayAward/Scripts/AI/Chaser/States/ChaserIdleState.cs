using UnityEngine;
using System.Collections;

public class ChaserIdleState : EnemiesBaseState
{
	public bool StartChase = false;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Player && !StartChase)
        {
            float Rotation = Quaternion.Dot(Player.transform.rotation, transform.rotation);
            if (Mathf.Abs(Rotation) <= 0.1)
            {
				StartChase = true;
				if(myAnimator)
				{
					myAnimator.Play("StartChasing");
				}
				Invoke("StartChasing", 2.0f);
            }
        }
	}

    [ContextMenu("StartChasing")]
    void StartChasing()
    {
        if (!enabled) return;

        if(CanGoToState("Chasing"))
        {
            GoToState("Chasing");
        }
    }
}
