using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Narrative;

namespace Game
{
    [DefaultExecutionOrder(ExecutionOrder)]
	public class Level : MonoBehaviour
	{
        public const int ExecutionOrder = -200;

		public static Level Instance { get; protected set; }

        public SayDialog SayDialog { get; protected set; }

        public LevelAR AR { get; protected set; }

        public LevelCameraSetup CameraSetup { get; protected set; }

        public AudioSource AudioSource { get; protected set; }

        private void Awake()
        {
            Instance = this;

            SayDialog = FindObjectOfType<SayDialog>();
            SayDialog.Hide();

            AR = FindObjectOfType<LevelAR>();

            CameraSetup = FindObjectOfType<LevelCameraSetup>();

            AudioSource = GetComponent<AudioSource>();
        }
    }
}