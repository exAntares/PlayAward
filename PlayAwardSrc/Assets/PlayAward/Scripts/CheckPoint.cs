using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.SendMessage("SetLastCheckPoint", gameObject.transform);
		}
	}
}
