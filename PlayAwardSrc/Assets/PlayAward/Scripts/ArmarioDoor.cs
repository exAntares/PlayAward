using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DoorScript))]
public class ArmarioDoor : MonoBehaviour
{
	protected DoorScript doorScript;

	// Use this for initialization
	void Start ()
	{
		doorScript = GetComponent<DoorScript>();
	}

	void OnMouseUpAsButton()
	{
		doorScript.OnUse();
	}
}
