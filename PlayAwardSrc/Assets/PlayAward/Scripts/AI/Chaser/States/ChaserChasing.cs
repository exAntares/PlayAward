using UnityEngine;
using System.Collections;

public class ChaserChasing : EnemiesBaseState
{
    public float Speed = 0.01f;
    public CharacterController Controller;

	// Use this for initialization
    override protected void InitState()
    {
        base.InitState();
        Controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
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
}
