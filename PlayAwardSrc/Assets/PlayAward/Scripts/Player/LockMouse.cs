using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour {
    public KeyCode Key = KeyCode.Escape;
    private bool _lockstate = true;

	// Use this for initialization
	void Start () {
        Screen.lockCursor = _lockstate;        
#if !UNITY_EDITOR
        Destroy(this);
#endif
    }

#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyUp(Key) && Screen.lockCursor != !_lockstate)
        {
            _lockstate = !_lockstate;
            Screen.lockCursor = _lockstate;
            Debug.Log("lock status: " + _lockstate);
        }
            
    }
#endif //Editor
}
