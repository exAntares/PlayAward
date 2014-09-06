using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using Actions;

[System.Serializable]
public class EventCondition : CCondition
{
    public EventsTypes.EEventsTypes Event;
    public EventsHandler EventOwner;

    public void Awake()
    {
        if (EventOwner)
        {
            EventOwner.RegisterFunctionToEvent(Execute, Event.ToString());
        }
    }

    public void Execute()
    {
        foreach (CAction action in _ca.Actions)
        {
            action.Play();
        }
    }
}
