using UnityEngine;
using System.Collections;

public class Vela : MonoBehaviour
{
	public int NumVela = 0;
	void OnUse()
	{
		print("Hola! soy la vela #" + NumVela);
	}
}
