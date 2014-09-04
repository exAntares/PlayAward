﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMode : Singleton<GameMode>
{
    public bool LoadDebugMaps = false;
    public DefaultObjects _DefaultObjects;
    public List<string> ScenesToLoad = new List<string>();
    public List<string> DebugMaps = new List<string>();

    private List<string> ScenesLoaded = new List<string>();
    private string thisLevel;

    private GameMode() { } // guarantee this will be always a singleton only - can't use the constructor!

    // Use this for initialization
    override public void Awake()
    {
        if (this != Instance)
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            DestroyImmediate(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        
        thisLevel = Application.loadedLevelName;
        print("Level Loaded " + thisLevel);

        LoadAllLevels();
    }

    void LoadAllLevels()
    {
        foreach (string scene in ScenesToLoad)
        {
            if (scene != thisLevel && !ScenesLoaded.Contains(scene))
            {
                Application.LoadLevelAdditive(scene);
                ScenesLoaded.Add(scene);
            }
        }

        if (LoadDebugMaps)
        {
            foreach (string scene in DebugMaps)
            {
                if (scene != thisLevel && !ScenesLoaded.Contains(scene))
                {
                    Application.LoadLevelAdditive(scene);
                    ScenesLoaded.Add(scene);
                }
            }
        }

        PostLoadLevels();
    }

    void PostLoadLevels()
    {
        _DefaultObjects.Init();
    }

}

[System.Serializable]
public class DefaultObjects
{
    public GameObject DefaultStartPoint;
	public GameObject DefaultPlayer;
	public GameObject DefaultFader;
    public GameObject GlobalEvents;

    public void Init()
    {
        GameObject _DefaultObjects = GameObject.Find("DefaultObjects") as GameObject;
        if (!_DefaultObjects)
        {
            _DefaultObjects = new GameObject("DefaultObjects");
        }

        GameObject tmpStartPoint = GameObject.FindGameObjectWithTag(DefaultStartPoint.tag) as GameObject;
        if (!tmpStartPoint)
        {
            DefaultStartPoint = GameObject.Instantiate(DefaultStartPoint) as GameObject;
            DefaultStartPoint.name = "DefaultStartPoint";
            DefaultStartPoint.transform.parent = _DefaultObjects.transform;
        }
        else
        {
            DefaultStartPoint = tmpStartPoint;
        }

        if (!GameObject.FindGameObjectWithTag(DefaultPlayer.tag))
        {
            DefaultPlayer = GameObject.Instantiate(DefaultPlayer, DefaultStartPoint.transform.position, DefaultStartPoint.transform.rotation) as GameObject;
            DefaultPlayer.name = "DefaultPlayer";
        }

        if (!GameObject.FindGameObjectWithTag(DefaultFader.tag))
        {
            DefaultFader = GameObject.Instantiate(DefaultFader) as GameObject;
            DefaultFader.name = "DefaultFader";
            DefaultFader.transform.parent = _DefaultObjects.transform;
        }

        if (GlobalEvents)
        {
            GlobalEvents = GameObject.Instantiate(GlobalEvents) as GameObject;
            GlobalEvents.name = "GlobalEvents";
        }
    }
}