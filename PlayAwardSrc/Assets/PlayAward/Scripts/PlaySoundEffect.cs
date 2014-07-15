using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySoundEffect : MonoBehaviour {
	public List<AudioClip> Sounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySoundEffectFromList(int index)
	{
		if(Sounds.Count > index)
		{
			AudioSource.PlayClipAtPoint(Sounds[index], transform.position);
		}
	}
}
