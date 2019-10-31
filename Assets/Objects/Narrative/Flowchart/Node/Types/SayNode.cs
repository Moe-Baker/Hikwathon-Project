﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Narrative.Characters;

namespace Game.Narrative
{
	public class SayNode : Node, IDialog
	{
        [SerializeField]
        Character character = null;
        public Character Character => character;

        [SerializeField]
        string text = "";
        public string Text => text;

        public SayDialog SayDialog => Level.Instance.SayDialog;

        public override void Execute()
        {
            base.Execute();

            SayDialog.OnProgress += SayDialogProgressCallback;

            SayDialog.Show(this);
        }

        private void SayDialogProgressCallback()
        {
            SayDialog.OnProgress -= SayDialogProgressCallback;

            End();
        }
    }
}