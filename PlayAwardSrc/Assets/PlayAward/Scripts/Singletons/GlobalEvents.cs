using UnityEngine;
using System.Collections;

public class GlobalEvents : MonoBehaviour
{
    //private GlobalEvents() { } // guarantee this will be always a singleton only - can't use the constructor!

    void Start()
    {
        //Start Game on chapter 1
        Cap1();
    }

    #region EditorHelpers;

    [ContextMenu("Capitulo 1")]
    public void Cap1()
    {
        gameObject.BroadCastEvent("Capitulo 1");
    }

    [ContextMenu("Capitulo 2")]
    public void Cap2()
    {
        gameObject.BroadCastEvent("Capitulo 2");
    }

    [ContextMenu("Capitulo 3")]
    public void Cap3()
    {
        gameObject.BroadCastEvent("Capitulo 3");
    }

    #endregion

    #region debug
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            Cap1();
        }
        else if(Input.GetKeyUp(KeyCode.F2))
        {
            Cap2();
        }
        else if(Input.GetKeyUp(KeyCode.F3))
        {
            Cap3();
        }
    }
    #endregion
}
