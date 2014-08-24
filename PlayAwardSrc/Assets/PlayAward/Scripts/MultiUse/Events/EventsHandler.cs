using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/*
 * Use gameObject.SendMessage("BroadCastEvent","OnEvent")
 * where OnEvent its the event you want to let know
 * */
public class EventsHandler : MonoBehaviour
{

    #region variables
    //Effects for setting on UnityEditor
    public List<Effect> SpawnEffects;

    //Effects for setting on UnityEditor
    public List<PlaySound> PlaySounds;

    //Spawn Objects
    public List<EventAction> SpawnGameObjects;

    //Actions for setting on UnityEditor
    public List<EventSendMessages> MessagesToSend;

    //Activation or deactivation list objects
    public List<ActivateObjectAction> ObjectsToActivate;
    
    //Table of Delegates by event's name <EventName, Delegate>
    public Dictionary<string, Action> DelegatesByEventName = new Dictionary<string, Action>();

    #endregion

    #region EventsInterface

    protected void AddDoActionToTable(EventExecuterBase ef)
    {
        string newEventName;
        //Let know we are the owner
        ef.setOwner(gameObject);
        //Add DoAction to its corresponding type
        newEventName = ef._Event.CustomEventName;
        RegisterFunctionToEvent(ef.DoAction, newEventName);
    }

    public void RegisterFunctionToEvent(Action FunctionVoidToAdd, string NamedEvent)
    {
        //Debug.Log(gameObject.name + " Registrando funcion " + FunctionVoidToAdd + " Al evento " + NamedEvent);
        if (DelegatesByEventName.ContainsKey(NamedEvent))
        {
            DelegatesByEventName[NamedEvent] += FunctionVoidToAdd;
        }
        else
        {
            DelegatesByEventName[NamedEvent] = FunctionVoidToAdd;
        }
    }

    public void UNRegisterFunctionToEvent(Action FunctionVoidToAdd, string NamedEvent)
    {
        //Debug.Log(gameObject.name + " Des Registrando funcion " + FunctionVoidToAdd + " Al evento " + NamedEvent);
        if (DelegatesByEventName.ContainsKey(NamedEvent))
        {
            DelegatesByEventName[NamedEvent] -= FunctionVoidToAdd;
        }
    }

    public Action GetEventAction(string EventName)
    {
        if (DelegatesByEventName.ContainsKey(EventName))
        {
            return DelegatesByEventName[EventName];
        }

        return null;
    }

    public void BroadCastEvent(string eventName)
    {
		//Debug.Log("Trying BroadCastingEvent: " + eventName);

        if (DelegatesByEventName.ContainsKey(eventName))
        {
            Action delegateAction = DelegatesByEventName[eventName];
            if (delegateAction != null)
            {
                //Debug.Log("BroadCastingEvent: " + eventName);
                delegateAction();
            }
        }
        else
        {
            //Debug.Log(gameObject + " No hay delegados asignados para " + eventName);
        }
       
    }

    #endregion

    #region GameObject Interface

    void Start()
    {
        //Add DoAction to its corresponding table value
        SpawnGameObjects.ForEach(AddDoActionToTable);
        //Add DoAction to its corresponding table value
        SpawnEffects.ForEach(AddDoActionToTable);
        //Add DoAction to its corresponding table value
        MessagesToSend.ForEach(AddDoActionToTable);
        //Add DoAction to its corresponding table value
        PlaySounds.ForEach(AddDoActionToTable);
        //Add DoAction to its corresponding table value
        ObjectsToActivate.ForEach(AddDoActionToTable);

        gameObject.BroadCastEvent("OnFinishStart");
    }

    private void OnDestroy()
    {
        DelegatesByEventName.Clear();
        SpawnGameObjects.Clear();
        SpawnEffects.Clear();
        MessagesToSend.Clear();
        PlaySounds.Clear();
        ObjectsToActivate.Clear();

		gameObject.BroadCastEvent("OnDestroy");
    }

	void OnBecameVisible()
	{
		gameObject.BroadCastEvent("OnBecameVisible");
	}

	void OnTriggerExit(Collider other)
	{
		gameObject.BroadCastEvent("OnTriggerExit");
	}
	
	#endregion

}

#region EventDefinitions

[System.Serializable]
public class EventExecuterBase
{
    [System.Serializable]
    public class EventType
    {
        public string CustomEventName = "";
    }

    public string ActionName    = "";
    public EventType _Event     = new EventType();

    protected GameObject Owner  = null;

    public virtual void DoAction() { }

    public virtual void Init() { }

    public void setOwner(GameObject newOwner)
    {
        Owner = newOwner;
    }

    public GameObject getOwner()
    {
        return Owner;
    }
}

[System.Serializable]
public class Effect : EventExecuterBase
{
    public GameObject MyParticleSystem = null;
    public Vector3 offsetPos = Vector3.zero;

    public override void DoAction()
    {
        GameObject thisEffectInstance = (GameObject)GameObject.Instantiate(MyParticleSystem, Owner.transform.position + offsetPos, Quaternion.identity);

        if (thisEffectInstance != null)
        {
            GameObject.DestroyObject(thisEffectInstance, 10.0f);
        }
    }
}

[System.Serializable]
public class PlaySound : EventExecuterBase
{
    public AudioClip MySoundToPlay = null;
    public float Volumen = 1.0f;
    public Vector3 SoundPos = Vector3.zero;

    public override void DoAction()
    {
        if (MySoundToPlay)
        {
            AudioSource.PlayClipAtPoint(MySoundToPlay, SoundPos, Volumen);
        }
    }
}

[System.Serializable]
public class EventAction : EventExecuterBase
{
    public GameObject PrefabToSpawn = null;

    public override void DoAction()
    {
        GameObject.Instantiate(PrefabToSpawn, Owner.transform.position, Quaternion.identity);
    }
}

[System.Serializable]
public class EventSendMessages : EventExecuterBase
{
    [System.Serializable]
    public class Mensaje
    {
        public GameObject Target = null;
        public string Message = "";
        public UnityEngine.Object Params = null;

    };

    public Mensaje MessageForSendMessage;

    public override void DoAction()
    {
        if (MessageForSendMessage != null && MessageForSendMessage.Target != null)
        {
            MessageForSendMessage.Target.SendMessage(MessageForSendMessage.Message, MessageForSendMessage.Params, SendMessageOptions.DontRequireReceiver);
        }
    }
}

[System.Serializable]
public class ActivateObjectAction : EventExecuterBase
{
    public GameObject ObjectInSceneToActivate = null;
    public bool Activate = true;

    public override void DoAction()
    {
        ObjectInSceneToActivate.SetActive(Activate);
    }
}

#endregion

#region ExtensionMethods

public static class EventsHandlerExtensionMethods
{

    public static bool BroadCastEvent(this GameObject go, string EventName)
    {
		EventsHandler MyEventsHandler = go.GetComponent<EventsHandler>();
		if(MyEventsHandler)
        {
			MyEventsHandler.BroadCastEvent(EventName);
            return true;
        }

        return false;
    }

	public static bool BroadCastEvent(this MonoBehaviour mono, string EventName)
	{
		EventsHandler MyEventsHandler = mono.GetComponent<EventsHandler>();
		if(MyEventsHandler)
		{
			MyEventsHandler.BroadCastEvent(EventName);
			return true;
		}
		
		return false;
	}

    public static void RegisterFunctionToEvent(this GameObject go, Action FunctionVoidToAdd, string NamedEvent)
    {
        EventsHandler MyEventsHandler = go.GetComponent<EventsHandler>();
		if (MyEventsHandler)
        {
			MyEventsHandler.RegisterFunctionToEvent(FunctionVoidToAdd, NamedEvent);
        }
    }

}

#endregion