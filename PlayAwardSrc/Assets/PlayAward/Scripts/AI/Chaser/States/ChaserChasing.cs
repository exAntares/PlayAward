using UnityEngine;
using System.Collections;

public class ChaserChasing : EnemiesBaseState
{
    public float Speed = 0.01f;
	public GameObject NewDoor;
	public Renderer myrenderer;

	protected CharacterController Controller;

	// Use this for initialization
    override protected void InitState()
    {
        base.InitState();
        Controller = GetComponent<CharacterController>();
    }

	public override void BeginState()
	{
		Invoke("StopChasing", 10.0f);
	}
	
	public override void EndState()
	{
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        if(Player)
        {
            Vector3 Direction = Player.transform.position - transform.position;
            Controller.Move(Direction.normalized * Speed);

			transform.LookAt(Player.transform, Vector3.up);
			transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			//print("collision " + other.gameObject);
			other.gameObject.SendMessage("Die");
			if(CanGoToState("Idle"))
			{
				GoToState("Idle");
			}
		}
	}

	void StopChasing()
	{
		if(!enabled) return;

		if(myrenderer && myrenderer.isVisible)
		{
			Invoke("StopChasing", 10.0f);
			return;
		}

		Destroy(gameObject, 0.1f);

		if(NewDoor)
		{
			GameObject newDoor = Instantiate(NewDoor) as GameObject;

			Vector3 NewPosition = newDoor.transform.position;
			NewPosition.x = transform.position.x;

			newDoor.transform.position = NewPosition;
		}
	}

}
