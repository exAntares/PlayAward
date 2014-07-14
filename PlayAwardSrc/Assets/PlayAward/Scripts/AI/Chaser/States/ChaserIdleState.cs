using UnityEngine;
using System.Collections;

public class ChaserIdleState : EnemiesBaseState
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(Player)
        {
            float Rotation = Quaternion.Dot(Player.transform.rotation, transform.rotation);
            if (Mathf.Abs(Rotation) <= 0.1)
            {
                StartChasing();
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
