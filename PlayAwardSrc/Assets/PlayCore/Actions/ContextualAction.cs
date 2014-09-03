using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;


[System.Serializable]
public class ContextualAction : PlayCoreBehaviour
{
    [ListElementCreator(typeof(CCondition))]
    public CCondition[] Conditions;

    [ListElementCreator(typeof(CAction))]
    public CAction[] Actions;

    protected void Awake()
    {
        foreach (CAction action in Actions)
        {
            action.Init(this);
        }

        foreach (CCondition condition in Conditions)
        {
            condition.Init(this);
        }
    }


#if UNITY_EDITOR
    public static class ContextualActionCreator
    {
        [MenuItem("GameObject/Create Other/Core/Contextual Action")]
        private static void CreateTrigger()
        {
            GameObject caObject = new GameObject();
            caObject.name = "Contextual Action";

            caObject.AddComponent<ContextualAction>();

        }

    }
#endif

}
