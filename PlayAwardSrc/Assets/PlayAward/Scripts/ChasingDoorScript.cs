using UnityEngine;
using System.Collections;

public class ChasingDoorScript : MonoBehaviour
{
	public float speed = 1.0f;

	protected GameObject Player;
	protected bool StopMoving = false;

	void Awake()
	{
		Player = gameObject.GetPlayer();
	}

	void FixedUpdate()
	{
		if(!StopMoving && Player)
		{
			float step = speed * Time.deltaTime;
			Vector3 newPos = transform.position;

			if(Mathf.Abs(transform.position.x - Player.transform.position.x) > 10.0f)
			{
				newPos.x = Mathf.MoveTowards(transform.position.x, Player.transform.position.x, step);
			}

			transform.position = newPos;
		}
	}

	void EventOnBecameVisible(GameObject VisibleObject)
	{
		StopMoving = true;
	}
	
}
