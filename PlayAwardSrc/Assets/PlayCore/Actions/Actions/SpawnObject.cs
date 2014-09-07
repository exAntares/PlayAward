using UnityEngine;
using System.Collections;

namespace Actions
{
    public class SpawnObject : CAction
    {
        public GameObject ObjectToSpawn;
        public Transform Position;

        public GameObject SpawnedObject;

        public override void Play()
        {
            SpawnedObject = GameObject.Instantiate(ObjectToSpawn, Position.position, Position.rotation) as GameObject;
        }

        public override void Stop()
        {
        }
    }
}
