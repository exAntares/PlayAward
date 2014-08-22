using UnityEngine;
using System.Collections;

public class AttachParticle : MonoBehaviour
{
    public GameObject Particle;

	// Use this for initialization
	void Start ()
    {
        if (Particle)
        {
            Particle = Instantiate(Particle, transform.position, transform.rotation) as GameObject;
            Particle.transform.parent = transform;
        }	
	}
}
