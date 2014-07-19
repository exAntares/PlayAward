using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public bool startAutoDestroy = false;
	public int msecsToDestroy = 100;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(startAutoDestroy)
		{
			gameObject.BroadcastMessage("DestroyingObj",SendMessageOptions.DontRequireReceiver);
			DestroyObject(gameObject,msecsToDestroy*0.001f);
		}
	}
	
	void StartAutoDestroy(int msecs = 100)
	{
		startAutoDestroy = true;
		msecsToDestroy = msecs;
	}
}
