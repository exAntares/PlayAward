using UnityEngine;
using System.Collections;

public class ResetOnPlayerRespawn : MonoBehaviour
{
	private GameObject Player;
	private Vector3 InitialPosition;
	private Quaternion InitialRotation;

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		if(Player)
		{
			Player.RegisterFunctionToEvent(OnPlayerRespawn,"OnRespawn");
		}

		InitialPosition = transform.position;
		InitialRotation = transform.rotation;
	}
	
	void OnPlayerRespawn()
	{
		BroadcastMessage("ResetObject", SendMessageOptions.DontRequireReceiver);

		transform.position = InitialPosition;
		transform.rotation = InitialRotation;
	}
}
