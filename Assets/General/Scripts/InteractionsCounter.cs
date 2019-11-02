using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game.Narrative
{
    public class InteractionsCounter : MonoBehaviour
    {
        public int target = 2;
		
		int count = 0;

        public Flowchart flowchart;

        public void Add()
		{
            count++;

            if (count >= target)
                flowchart.Execute();
		}
    }
}