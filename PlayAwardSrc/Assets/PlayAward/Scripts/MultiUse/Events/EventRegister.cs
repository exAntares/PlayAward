using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventRegister : MonoBehaviour
{

	public List<ObjectAndEvent> Events = new List<ObjectAndEvent>();

	// Use this for initialization
	void Awake()
	{
		RegisterEvents();
	}

	public void RegisterEvents()
	{
		foreach(ObjectAndEvent EventObject in Events)
		{
			EventObject.Init(gameObject);
		}
	}

}

[System.Serializable]
public class ObjectAndEvent
{

	public GameObject EventObject = null;
	public string EventName = "";

	protected GameObject Owner = null;

	public void Init(GameObject newOwner)
	{
		Owner = newOwner;
		if(Owner)
		{
			if(EventObject)
			{
				EventObject.RegisterFunctionToEvent(OnEvent, EventName);
			}
		}
	}

	public void OnEvent()
	{
		Owner.BroadcastMessage("Event"+EventName, EventObject);
	}
}