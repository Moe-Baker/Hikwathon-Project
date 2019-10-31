using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Narrative;

namespace Game
{
    [DefaultExecutionOrder(-200)]
	public class Level : MonoBehaviour
	{
		public static Level Instance { get; protected set; }

        public SayDialog SayDialog { get; protected set; }

        private void Awake()
        {
            Instance = this;

            SayDialog = FindObjectOfType<SayDialog>();
            SayDialog.Hide();
        }
    }
}