using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative
{
	public class PlaySoundNode : Node
	{
        public AudioClip clip;

        public override void Execute()
        {
            base.Execute();

            Level.Instance.AudioSource.PlayOneShot(clip);

            End();
        }
    }
}