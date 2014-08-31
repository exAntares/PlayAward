using UnityEngine;
using System.Collections;

public class DoorScript : UsableObject
{
	public enum DoorState
	{
        Closed,
		OpenIn,
        OpenOut
	}

    public bool Locked = false;
	public DoorState State = DoorState.Closed;
	[Range(0.0f,1.0f)]
	public float DoorPosition = 0.0f;
	public Animator myAnimator;
	public float Speed = 0.01f;

	void FixedUpdate()
	{
		switch(State)
		{
        case DoorState.OpenOut:
            if (DoorPosition > -1.0f)
            {
                DoorPosition -= Speed * Time.deltaTime;
            }
            else
            {
                DoorPosition = -1.0f;
            }

            break;
		case DoorState.OpenIn:
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
            if (DoorPosition < 0.0f)
            {
                DoorPosition += Speed * Time.deltaTime;
            }
            else if (DoorPosition > 0.0f)
            {
                DoorPosition -= Speed * Time.deltaTime;
            }

            if(Mathf.Abs(DoorPosition) <= 0.1f)
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
        if (Locked) return;

		switch(State)
		{
        case DoorState.OpenOut:
            State = DoorState.Closed;
            break;
		case DoorState.OpenIn:
			State = DoorState.Closed;
			break;
        case DoorState.Closed:
            {
                print(Quaternion.Dot(User.transform.rotation, transform.parent.transform.rotation));

                if (Mathf.Abs(Quaternion.Dot(User.transform.rotation, transform.parent.transform.rotation)) <= 0.7f)
                {
                    State = DoorState.OpenIn;
                }
                else
                {
                    State = DoorState.OpenOut;
                }
            }
            break;
		}
	}

	void EventOnTriggerExit(GameObject Trigger)
	{
		State = DoorState.Closed;
	}

}
