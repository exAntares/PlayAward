using UnityEngine;
using System.Collections;
using System;

[AddComponentMenu("")]
public abstract class CPropertyBase : PlayCoreBehaviour
{
    public string Name;

    void OnValidate()
    {
        hideFlags = HideFlags.HideInInspector | HideFlags.HideInHierarchy;
        enabled = true;
    }

    public abstract Type ValueType { get; }

    public virtual void SetValue(CPropertyBase srcBaseProp)
    {
    }

    public virtual bool IsSameValue(CPropertyBase srcBaseProp)
    {
        return false;
    }
}
