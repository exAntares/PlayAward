using UnityEngine;
using System.Collections;

namespace Actions
{
    public class DestoyObject : CAction
    {
        public GameObject ObjectToDestroy;

        public override void Play()
        {
            Destroy(ObjectToDestroy);
        }

        public override void Stop()
        {
        }
    }
}
