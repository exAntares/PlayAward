using UnityEngine;
using System.Collections;

[AddComponentMenu("")]
[System.Serializable]
public abstract class CCondition : PlayCoreBehaviour
{
    protected ContextualAction _ca;
    public void Init(ContextualAction ca)
    {
        _ca = ca;
    }

    void OnValidate()
    {
        hideFlags = HideFlags.HideInInspector | HideFlags.HideInHierarchy;
        enabled = true;
    }
}
