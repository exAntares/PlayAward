using UnityEngine;
using System.Collections;

public class UseItem : MonoBehaviour
{
	public float CooldDown = 1.0f;
	protected float InternalCooldDown = 0.0f;

	void Start()
	{
		StartCoroutine(StartCooldown());
	}

	void OnTriggerStay(Collider other)
	{
		if(CanBeUsed() && other.tag == "Player")
		{
			if(Input.GetButton("Use"))
			{
				BroadcastMessage("OnUse");
				StartCoroutine(StartCooldown());
			}
		}
	}

	IEnumerator StartCooldown()
	{
		InternalCooldDown = 0.0f;
		while(InternalCooldDown < CooldDown)
		{
			InternalCooldDown += Time.deltaTime;
			yield return 0;
		}

		InternalCooldDown = CooldDown;
	}

	public bool CanBeUsed()
	{
		return (InternalCooldDown == CooldDown);
	}

}
