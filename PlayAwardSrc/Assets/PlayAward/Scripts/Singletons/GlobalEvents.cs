using UnityEngine;
using System.Collections;

public class GlobalEvents : Singleton<GlobalEvents>
{

    public Chapters StartingChapter = Chapters.Chapter1;

    private GlobalEvents() { } // guarantee this will be always a singleton only - can't use the constructor!

    public enum Chapters
    {
        Chapter1,
        Chapter2,
        Chapter3
    }     
    
    void Start()
    {
        /*Invoke later since the flow its
         * Load scenes
         * Spawn Default Objects
         * Start of default objects
         * start of loaded scenes objects
        */ 
        Invoke("StartChapter", 0.1f);
    }

    void StartChapter()
    {
        switch (StartingChapter)
        {
            case Chapters.Chapter1:
                //Start Game on chapter 1
                Cap1();
                break;
            case Chapters.Chapter2:
                //Start Game on chapter 1
                Cap2();
                break;
            case Chapters.Chapter3:
                //Start Game on chapter 1
                Cap3();
                break;
        }
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
