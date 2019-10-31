﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative
{
    public class Flowchart : MonoBehaviour
    {
        public IList<Node> Nodes { get; protected set; }

        int index = 0;

        private void Awake()
        {
            Nodes = GetComponentsInChildren<Node>();
        }

        private void Start()
        {
            
        }

        public void Execute()
        {
            index = 0;

            void Chain()
            {
                Nodes[index].OnEnd -= Chain;

                index++;

                if(index < Nodes.Count)
                {
                    Nodes[index].OnEnd += Chain;
                    Nodes[index].Execute();
                }
                else
                {
                    End();
                }
            }

            Nodes[index].OnEnd += Chain;
            Nodes[index].Execute();
        }

        public event Action OnEnd;
        void End()
        {
            OnEnd?.Invoke();
        }
    }
}