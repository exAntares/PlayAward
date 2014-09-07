using UnityEngine;
using System.Collections;

namespace Actions
{
    public class PlaySoundEffect : CAction
    {
        public AudioClip Audio;
        public Transform AudioPosition;

        public override void Play()
        {
            AudioSource.PlayClipAtPoint(Audio, AudioPosition.position);
        }

        public override void Stop()
        {
        }
    }
}
