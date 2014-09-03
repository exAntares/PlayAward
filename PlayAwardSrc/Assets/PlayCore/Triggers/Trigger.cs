using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

namespace Core.Triggers
{    
    public class Trigger : PlayCoreBehaviour
    {
        #region delegate
        public OnEnterDelegate OnEnter;
        public OnExitDelegate OnExit;

        public delegate void OnEnterDelegate(GameObject go);
        public delegate void OnExitDelegate(GameObject go);
        #endregion

        Collider trigger;                
        
        #region messages
        public void Awake()
        {
            trigger = gameObject.GetComponent<Collider>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (OnEnter != null)
                OnEnter(other.gameObject);
        }

        void OnTriggerExit(Collider other)
        {
            if (OnExit != null)
                OnExit(other.gameObject);
        }
        #endregion //messages
    }

#if UNITY_EDITOR
    public static class TriggerCreator
    {
        [MenuItem("GameObject/Create Other/Core/Trigger")]
        private static void CreateTrigger()
        {
            GameObject triggerObject = new GameObject();
            triggerObject.name = "Trigger";

            BoxCollider trigger = triggerObject.AddComponent<BoxCollider>();

            if (trigger != null)
                trigger.isTrigger = true;

            triggerObject.AddComponent<Trigger>();
        }

    }
#endif

}