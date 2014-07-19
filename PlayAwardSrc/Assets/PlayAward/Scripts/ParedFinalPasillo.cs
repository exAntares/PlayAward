using UnityEngine;
using System.Collections;

public class ParedFinalPasillo : MonoBehaviour {

	public float speed = 0.1f;
	public float PlayerDistance = 20.0f;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Player && Vector3.Distance(transform.position, Player.transform.position) < PlayerDistance)
		{
			Vector3 Direction = transform.forward;
			transform.position += Direction * speed;
		}
	}
}
