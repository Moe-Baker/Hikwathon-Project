﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative
{
	public class EndPageNode : Node
	{
        public Page target;

        public override void Execute()
        {
            base.Execute();

            target.End();

            End();
        }
    }
}