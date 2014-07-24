using UnityEngine;
using System.Collections;

public class DeadState : PlayerStateBase
{
	public Transform LastCheckPoint;

	public override void BeginState()
	{
		gameObject.BroadcastMessage("DisableInput");
		Invoke("Respawn", 2.5f);
	}
	
	public override void EndState()
	{
		gameObject.BroadcastMessage("EnableInput");
	}

	public override void Die()
	{
		//Override so we dont die when dead
	}

	void SetLastCheckPoint(Transform CheckPoint)
	{
		LastCheckPoint = CheckPoint;
	}

	void Respawn()
	{
		if(enabled)
		{
			gameObject.transform.position = LastCheckPoint.position;
			GoToState("Normal");

			this.BroadCastEvent("OnRespawn");
		}
	}
}
