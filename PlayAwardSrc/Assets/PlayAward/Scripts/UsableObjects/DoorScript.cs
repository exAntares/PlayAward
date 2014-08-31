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
    public DoorSounds Sounds = null;
    public bool Locked = false;

	public DoorState State = DoorState.Closed;
	[Range(0.0f,1.0f)]
	public float DoorPosition = 0.0f;
	public Animator myAnimator;
	public float Speed = 0.01f;

	void FixedUpdate()
	{


		if(myAnimator)
		{
			myAnimator.SetFloat("Opening",DoorPosition);
		}
	}

    override public void OnUse(GameObject User)
	{
        if (Locked)
        {
            if (Sounds != null && Sounds.LockedSound)
            {
                AudioSource.PlayClipAtPoint(Sounds.LockedSound, transform.position);
            }
            return;
        }

		switch(State)
		{
        case DoorState.Closed:
            {
                print(Quaternion.Dot(User.transform.rotation, transform.parent.transform.rotation));
                
                PlayOpenSound();

                if (Mathf.Abs(Quaternion.Dot(User.transform.rotation, transform.parent.transform.rotation)) <= 0.7f)
                {
                    if (myAnimator)
                    {
                        myAnimator.SetTrigger("Open_in");
                    }
                    State = DoorState.OpenIn;
                }
                else
                {
                    if (myAnimator)
                    {
                        myAnimator.SetTrigger("Open_out");
                    }
                    State = DoorState.OpenOut;
                }
            }
            break;
		}
	}

    public void PlayOpenSound()
    {
        if (Sounds != null && Sounds.OpenSound)
        {
            AudioSource.PlayClipAtPoint(Sounds.OpenSound, transform.position);
        }
    }

    public void PlayClosedSound()
    {
        if (Sounds != null && Sounds.ClosedSound)
        {
            AudioSource.PlayClipAtPoint(Sounds.ClosedSound, transform.position);
        }
    }

	void EventOnTriggerExit(GameObject Trigger)
	{
        switch (State)
        {
            case DoorState.OpenOut:
                {
                    if (myAnimator)
                    {
                        myAnimator.SetTrigger("Closed_out");
                    }
                }
                break;
            case DoorState.OpenIn:
                {
                    if (myAnimator)
                    {
                        myAnimator.SetTrigger("Closed_in");
                    }
                }
                break;
        }

		State = DoorState.Closed;
	}

}

[System.Serializable]
public class DoorSounds
{
    public AudioClip LockedSound = null;
    public AudioClip OpenSound = null;
    public AudioClip ClosedSound = null;
}