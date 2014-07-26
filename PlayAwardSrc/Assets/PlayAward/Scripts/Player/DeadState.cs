using UnityEngine;
using System.Collections;

public class DeadState : PlayerStateBase
{
	public AudioClip DeathSound;
	public ScreenFadeInOut Fader;
	protected Transform LastCheckPoint;

	protected override void InitState()
	{
		base.InitState();
		GameObject GoFader = GameObject.FindGameObjectWithTag("Fader");
		if(GoFader)
		{
			Fader = GoFader.GetComponent<ScreenFadeInOut>();
		}

	}

	public override void BeginState()
	{
		gameObject.BroadcastMessage("DisableInput");
		if(DeathSound)
		{
			AudioSource.PlayClipAtPoint(DeathSound, transform.position);
		}

		if(Fader)
		{
			Fader.FadeInOut();
		}

		Invoke("Respawn", 6.0f);
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
