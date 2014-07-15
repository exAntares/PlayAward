using UnityEngine;
using System.Collections;

public class SpawnFootStepDecal : MonoBehaviour {

	public GameObject LeftFootStepProjector;
	public GameObject RightFootStepProjector;

	public Transform RightFootPosition;
	public Transform LeftFootPosition;

	public void SpawnLeftFootDecal()
	{
		doSpawnFootStepDecal(LeftFootStepProjector, LeftFootPosition.position);
	}

	public void SpawnRightFootDecal()
	{
		doSpawnFootStepDecal(RightFootStepProjector, RightFootPosition.position);
	}

	void doSpawnFootStepDecal(GameObject ProjectorPrefab, Vector3 newPosition)
	{
		GameObject FootStep = GameObject.Instantiate(ProjectorPrefab, newPosition, ProjectorPrefab.transform.rotation) as GameObject;
		GameObject DynamicObjs = GameObject.Find("DynamicObjects");
		DynamicObjs = DynamicObjs ? DynamicObjs: new GameObject("DynamicObjects");
		if(DynamicObjs)
		{
			FootStep.transform.parent = DynamicObjs.transform;
		}
	}

}
