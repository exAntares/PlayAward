using UnityEngine;
using System.Collections;

public class DoorScript : UsableObject
{
	public enum DoorState
	{
		Closed,
		Open
	}

	public DoorState State = DoorState.Closed;
	[Range(0.0f,1.0f)]
	public float DoorPosition = 0.0f;
	public Animator myAnimator;
	public float Speed = 0.01f;

	void FixedUpdate()
	{
		switch(State)
		{
		case DoorState.Open:
			if(DoorPosition < 1.0f)
			{
				DoorPosition += Speed * Time.deltaTime;
			}
			else
			{
				DoorPosition = 1.0f;
			}

			break;
		case DoorState.Closed:
			if(DoorPosition > 0.0f)
			{
				DoorPosition -= Speed * Time.deltaTime;
			}
			else
			{
				DoorPosition = 0.0f;
			}

			break;
		}

		if(myAnimator)
		{
			myAnimator.SetFloat("Opening",DoorPosition);
		}
	}

    override public void OnUse(GameObject User)
	{
		switch(State)
		{
		case DoorState.Open:
			State = DoorState.Closed;
			break;
		case DoorState.Closed:
			State = DoorState.Open;
			break;
		}
	}

	void EventOnTriggerExit(GameObject Trigger)
	{
		State = DoorState.Closed;
	}

}
