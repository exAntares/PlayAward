using UnityEngine;
using System.Collections;

public class CameraUseRay : MonoBehaviour
{
	public GUIStyle textStyle;
	protected float CoolDownTimer = 0.2f;
	protected bool bCoolDown = false;
	protected GameObject UsableObject;

	public Texture2D GuiTexture;

	void Start()
	{
		CreateCrossHair();
	}

	void CreateCrossHair()
	{
		GuiTexture = new Texture2D(Screen.width, Screen.height);
		int y = 0;
		while (y < GuiTexture.height)
		{
			int x = 0;
			while (x < GuiTexture.width)
			{
				Color color = Color.clear;
				GuiTexture.SetPixel(x, y, color);
				++x;
			}
			++y;
		}
		
		int startWidth = (int)(Screen.width * 0.499f);
		int endWidth = (int)(Screen.width * 0.501f);
		int startHeight = (int)(Screen.height * 0.499f);
		int CrosshairDimension = (endWidth - startWidth);
		
		for(int i = startWidth; i <= startWidth + CrosshairDimension ; i++)
		{
			for(int k = startHeight; k <= startHeight + CrosshairDimension; k++)
			{
				GuiTexture.SetPixel(i, k, Color.white);
			}
		}
		
		GuiTexture.Apply();
	}

	void FixedUpdate ()
	{
		float Distance = 3.0f;
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));   
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * Distance, Color.yellow);
		if(Physics.Raycast(ray, out hit, Distance))
		{
			UsableObject = hit.collider.gameObject;
			if(UsableObject)
			{
				IUsable itemusable = UsableObject.GetComponent(typeof(IUsable)) as IUsable;
				if(itemusable != null)
				{
					//print("Item Usable!!!");
				}
				else
				{
					//UsableObject = null;
				}
			}

			if(!bCoolDown && UsableObject && Input.GetButton("Use"))
			{
				UsableObject.SendMessage("OnUse", SendMessageOptions.DontRequireReceiver);
				StartCoolDown();
			}
		}
		else
		{
			UsableObject = null;
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

	void OnGUI()
	{
		if(UsableObject)
		{
			float xMin = (Screen.width / 2);
			float yMin = (Screen.height / 2);
			GUI.Label(new Rect(xMin, yMin, 100, 100), UsableObject.name, textStyle);
		}

		if (GuiTexture)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), GuiTexture, ScaleMode.StretchToFill);
		}
	}

}
