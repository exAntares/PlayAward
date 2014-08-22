using UnityEngine;
using System.Collections;

public class PlayerController : StatesController
{

}


public static class PlayerExtensionMethods
{
	public static GameObject GetPlayer(this GameObject gameObject)
	{
		return GameObject.FindGameObjectWithTag("Player");
	}
}