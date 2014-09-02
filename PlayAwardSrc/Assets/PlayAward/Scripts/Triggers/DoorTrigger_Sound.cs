using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorTrigger_Sound : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public List<Animator> PuertasAnimar;
    public string AnimationName = "NOMBRE_DE_LA_ANIMACION";

    void OnTriggerEnter(Collider other)
    {
        if (SoundToPlay)
        {
            AudioSource.PlayClipAtPoint(SoundToPlay, transform.position);
        }
        
        DoorsPlayAnimation(AnimationName);
    }

    void DoorsPlayAnimation(string AnimationName)
    {
        foreach (Animator anim in PuertasAnimar)
        {
            anim.Play(AnimationName);
        }
    }
}
