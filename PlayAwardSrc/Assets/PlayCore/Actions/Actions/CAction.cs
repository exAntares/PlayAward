using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class CAction : PlayCoreBehaviour
{
    protected ContextualAction _ca;
    public void Init(ContextualAction ca)
    {
        _ca = ca;
    }
    public abstract void Play();
    public abstract void Stop();
}
