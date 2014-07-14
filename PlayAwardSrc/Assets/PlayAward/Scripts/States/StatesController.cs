using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatesController : MonoBehaviour {
	
	public string DefaultStateName;
	
	private string NextStateName;
	private string CurrentStateName = "";
	private StateBase DefaultState;
	private StateBase NextState;
	private StateBase CurrentState;

    private Dictionary<string, StateBase> AllStates;

	// Use this for initialization
	void Awake () {

        AllStates = new Dictionary<string, StateBase>();

		NextStateName = "";
		
		GoToState(DefaultStateName);
	}

    void Start()
    {
        //Disable all states but DefaultState
        foreach (KeyValuePair<string, StateBase> state in AllStates)
        {
            if (state.Key != DefaultStateName)
            {
                state.Value.enabled = false;
            }
            else
            {
                state.Value.enabled = true;
            }
        }
    }

	public void GoToState(string newStateName)
	{
		NextStateName = newStateName;
	}
	
	// Update is called once per frame
	void Update () {
		if(NextStateName!="")
		{
			swapStates();
		}
	}
	
	void swapStates()
	{
        NextState = GetState(NextStateName);

		if(NextState)
		{
			NextState.setStateController(this);
			
			if(CurrentState)
			{
				CurrentState.enabled = false;
				CurrentState.EndState();
			}
			
			CurrentStateName = NextStateName;
			CurrentState = NextState;
			CurrentState.enabled = true;
			CurrentState.Invoke("BeginState",0.1f);
			
		}else
		{
			Debug.LogError("StatesController: Unexisting NextState " + NextStateName + " " + gameObject.name);
		}
		
		NextStateName = "";
		NextState = null;
	}
	
	public string GetCurrentStateName()
	{
		return CurrentStateName;
	}

    public bool CanGoToState(string newState)
    {
        StateBase StateTest = GetState(newState);
        if (StateTest)
        {
            return StateTest.CanEnterState();
        }

        return false;
    }

    public StateBase GetState(string stateName)
    {
        StateBase returnState = null;

        if (AllStates.ContainsKey(stateName))
        {
            returnState = AllStates[stateName];
        }
        else
        {
            returnState = gameObject.GetComponent(stateName) as StateBase;
        }

        return returnState;
    }

    public void RegisterState(StateBase StateToRegister)
    {
        if (StateToRegister && StateToRegister.StateName != "")
        {
            //Debug.Log("RegisterState: " + StateToRegister.StateName + " From: " + StateToRegister.name);
            AllStates[StateToRegister.StateName] = StateToRegister;
        }
    }

}
