using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative.Characters
{
    [CreateAssetMenu]
	public class Character : ScriptableObject
	{
        [SerializeField]
        string displayName = "";
        public string DisplayName => displayName;
	}
}