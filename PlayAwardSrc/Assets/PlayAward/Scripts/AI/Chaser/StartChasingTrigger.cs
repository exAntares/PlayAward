using UnityEngine;
using System.Collections;

public class StartChasingTrigger : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		if(transform.parent)
		{
			ChaserIdleState IdleState = transform.parent.GetComponent<ChaserIdleState>();
				
			if(IdleState)
			{
				IdleState.bCanStartChasing = true;
				IdleState.DelayedStartChasing(5.0f);
			}
		}
	}

}
