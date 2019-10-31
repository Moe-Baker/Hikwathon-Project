using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative
{
	public class CloseDialogNode : Node
	{
        public SayDialog SayDialog => Level.Instance.SayDialog;

        public override void Execute()
        {
            base.Execute();

            SayDialog.Hide();

            End();
        }
    }
}