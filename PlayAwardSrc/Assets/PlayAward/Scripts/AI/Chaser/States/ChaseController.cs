using UnityEngine;
using System.Collections;

public class ChaseController : StatesController
{
	private Vector3 InitialPosition;
	private Quaternion InitialRotation;

	public override void Init()
	{
		base.Init();
		InitialPosition = transform.position;
		InitialRotation = transform.rotation;
	}

	void ResetObject()
	{
		transform.position = InitialPosition;
		transform.rotation = InitialRotation;
		GoToState("Idle");
	}
}
