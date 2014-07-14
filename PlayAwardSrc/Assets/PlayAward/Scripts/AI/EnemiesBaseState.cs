using UnityEngine;
using System.Collections;

public class EnemiesBaseState : StateBase
{
    protected GameObject Player;
	// Use this for initialization
    override protected void InitState()
    {
        base.InitState();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
