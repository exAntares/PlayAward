using UnityEngine;
using System.Collections;

public class GlobalEvents : MonoBehaviour
{
    //private GlobalEvents() { } // guarantee this will be always a singleton only - can't use the constructor!

    void Start()
    {
        int a;
        print("GlobalEvents Start");
    }

    [ContextMenu("Capitulo 2")]
    public void Cap2()
    {
        gameObject.BroadCastEvent("Capitulo 2");
    }
}
