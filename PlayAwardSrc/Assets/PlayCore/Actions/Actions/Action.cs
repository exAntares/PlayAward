using UnityEngine;
using System.Collections;



public class ActiveAction : CAction
{
    

    [SerializeField]
    private bool Inverse;
    public GameObject ObjectTarget;

    public override void Play()
    {
        ObjectTarget.SetActive(!Inverse);
    }

    public override void Stop()
    {
        ObjectTarget.SetActive(Inverse);
    }
}


