using UnityEngine;
using System.Collections;

public class CameraUseRay : MonoBehaviour
{
	protected float CoolDownTimer = 0.2f;
	protected bool bCoolDown = false;

	void FixedUpdate ()
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));   
		RaycastHit hit;
		if(!bCoolDown && Physics.Raycast(ray, out hit, 100.0f))
		{
			if(Input.GetButton("Use"))
			{
				hit.collider.gameObject.SendMessage("OnUse", SendMessageOptions.DontRequireReceiver);
				StartCoolDown();
			}
		}
	}

	void StartCoolDown()
	{
		bCoolDown = true;
		Invoke("StopCoolDown", CoolDownTimer);
	}

	void StopCoolDown()
	{
		bCoolDown = false;
	}
}
