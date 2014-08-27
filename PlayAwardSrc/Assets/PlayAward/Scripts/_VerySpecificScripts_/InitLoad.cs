using UnityEngine;
using System.Collections;

public class InitLoad : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Invoke("InitGame", 5.0f);
	}

    void InitGame()
    {
        Application.LoadLevel("Main_Hall_Design");
    }
}
