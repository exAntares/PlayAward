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
            CollisionFlags CF = Controller.Move(Direction.normalized * Speed);
        }
	}
}
