using UnityEngine;
using System.Collections;

public class StateBase : MonoBehaviour {

    public string StateName = "";
	private StatesController _SC;
    protected bool bCanEnterState = true;

    void Awake()
    {
        //Debug.Log(" Start StateBase " + StateName);
        _SC = GetComponent<StatesController>();
        InitState();
    }

    virtual protected void InitState()
    {
        RegisterState();
    }

    virtual public bool CanEnterState()
    {
        return bCanEnterState;
    }

	public virtual void BeginState()
	{
		//Debug.Log ("StateBase BeginState");
	}
	
	public virtual void EndState()
	{
		//Debug.Log ("StateBase EndState");
	}
	
	public void setStateController(StatesController SC)
	{
		_SC = SC;
	}
	
	public void GoToState(string newState)
	{
		if(_SC)
		{
			_SC.GoToState(newState);
		}
		else
		{
			Debug.LogError("StateBase THERE IS NO StatesController");
		}
	}

    public bool CanGoToState(string newState)
    {
        return _SC.CanGoToState(newState);
    }

    public void RegisterState()
    {
        if (_SC)
        {
            _SC.RegisterState(this);
        }
        else
        {
            Debug.LogError("StateBase CANT RegisterState NO StatesController");
        }
    }
}
