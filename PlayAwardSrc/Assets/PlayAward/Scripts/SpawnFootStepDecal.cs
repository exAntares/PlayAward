using UnityEngine;
using System.Collections;

public class SpawnFootStepDecal : MonoBehaviour {

	public GameObject LeftFootStepProjector;
	public GameObject RightFootStepProjector;

	public Transform RightFootPosition;
	public Transform LeftFootPosition;

	public AudioClip FootStepSound;
	[Range(0,1)]
	public float FootStepVolume = 1.0f;

	public void SpawnLeftFootDecal()
	{
		doSpawnFootStepDecal(LeftFootStepProjector, LeftFootPosition);
	}

	public void SpawnRightFootDecal()
	{
		doSpawnFootStepDecal(RightFootStepProjector, RightFootPosition);
	}

	void doSpawnFootStepDecal(GameObject ProjectorPrefab, Transform newTransform)
	{
		GameObject FootStep = GameObject.Instantiate(ProjectorPrefab, newTransform.position, newTransform.rotation) as GameObject;
		GameObject DynamicObjs = GameObject.Find("DynamicObjects");
		DynamicObjs = DynamicObjs ? DynamicObjs: new GameObject("DynamicObjects");
		if(DynamicObjs)
		{
			FootStep.transform.parent = DynamicObjs.transform;
		}

		if(FootStepSound)
		{
			AudioSource.PlayClipAtPoint(FootStepSound, transform.position, FootStepVolume);
		}
	}

}
