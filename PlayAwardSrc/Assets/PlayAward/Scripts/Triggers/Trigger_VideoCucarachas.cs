using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger_VideoCucarachas : MonoBehaviour
{
    public GameObject       ParticulasCucarachas;
    public Transform        Posicion_Particulas;
    public List<Animator>   LucesConAnimacion;
    public string           AnimationName = "NOMBRE_DE_LA_ANIMACION";

    void OnTriggerEnter(Collider other)
    {
        SpawnCucarachas(Posicion_Particulas, ParticulasCucarachas);
        LucesPlayAnimation(AnimationName);
    }

    void SpawnCucarachas(Transform position, GameObject Particles)
    {
        if (position)
        {
            if(Particles)
            {
                Instantiate(Particles, position.position, Particles.transform.rotation);
            }
        }
        else
        {
            if (Particles)
            {
                Instantiate(Particles);
            }
        }
    }

    void LucesPlayAnimation(string AnimationName)
    {
        foreach(Animator anim in LucesConAnimacion)
        {
            anim.Play(AnimationName);
        }
    }
}
