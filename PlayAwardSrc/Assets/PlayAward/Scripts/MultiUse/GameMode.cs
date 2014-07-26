using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMode : MonoBehaviour {

	public NeededObjects NecessaryObjects;

	// Use this for initialization
	void awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class NeededObjects
{
	public GameObject Player;
	public GameObject StartPoint;
	public GameObject Fader;

	public List<GameObject> Others;
}