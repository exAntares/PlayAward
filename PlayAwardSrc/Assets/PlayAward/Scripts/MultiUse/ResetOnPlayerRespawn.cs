using UnityEngine;
using System.Collections;

public class ResetOnPlayerRespawn : MonoBehaviour
{
	private GameObject Player;

	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		if(Player)
		{
			Player.RegisterFunctionToEvent(OnPlayerRespawn,"OnRespawn");
		}
	}
	
	void OnPlayerRespawn()
	{
		BroadcastMessage("ResetObject");
	}
}
