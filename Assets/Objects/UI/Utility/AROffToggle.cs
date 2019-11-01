using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Toggle))]
	public class AROffToggle : MonoBehaviour
	{
        Toggle toggle;

        public Level Level => Level.Instance;

        private void Start()
        {
            toggle = GetComponent<Toggle>();

            toggle.onValueChanged.AddListener(ValueChanged);
        }

        void ValueChanged(bool newValue)
        {
            Level.AR.Active = !newValue;
        }
    }
}