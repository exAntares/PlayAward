using UnityEngine;
using System.Collections;

using Actions;

public class NamedEventCondition : CCondition
{
    public string EventName;
    public EventsHandler EventOwner;

    public void Awake()
    {
        if (EventOwner)
        {
            EventOwner.RegisterFunctionToEvent(Execute, EventName);
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
