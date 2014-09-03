using UnityEngine;
using System.Collections;

enum Condition
{
    OnTriggerEnter,
    OnTriggerExit,
}

[System.Serializable]
public class TriggerCondition : CCondition
{
    public Core.Triggers.Trigger Trigger;
    [SerializeField]
    Condition _condition;

    public void Awake()
    {
        switch(_condition)
        {
            case Condition.OnTriggerEnter:
                Trigger.OnEnter += OnEnter;
                break;
            case Condition.OnTriggerExit:
                Trigger.OnExit += OnExit;
                break;
        }
        
    }

    public void OnEnter(GameObject go)
    {
        foreach(CAction action in _ca.Actions)
        {
            action.Play();
        }
    }

    public void OnExit(GameObject go)
    {        
        foreach (CAction action in _ca.Actions)
        {
            action.Play();
        }
    }
}