using UnityEngine;
using System.Collections;

public class SpawnFootStepDecal : MonoBehaviour {

	public GameObject FootStepProjector;

	public Transform RightFootPosition;
	public Transform LeftFootPosition;

	public void SpawnLeftFootDecal()
	{
		GameObject.Instantiate(FootStepProjector,LeftFootPosition.position, FootStepProjector.transform.rotation);
	}

	public void SpawnRightFootDecal()
	{
		GameObject.Instantiate(FootStepProjector,RightFootPosition.position, FootStepProjector.transform.rotation);
	}

}
