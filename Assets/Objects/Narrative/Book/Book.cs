using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace Game.Narrative
{
    [RequireComponent(typeof(Animator))]
	public class Book : MonoBehaviour
	{
		public IList<Page> Pages { get; protected set; }
        int index;

        public Animator Animator { get; protected set; }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        private void Start()
        {
            Pages = GetComponentsInChildren<Page>();

            for (int i = 0; i < Pages.Count; i++)
            {
                Pages[i].Init(this);

                Pages[i].Visible = (i == 0);
            }
        }

        public void Open()
        {
            Animator.SetTrigger("Open");
        }

        public void Begin()
        {
            Begin(0);
        }

        public void Begin(Page page)
        {
            index = Pages.IndexOf(page);

            Begin(index);
        }
        void Begin(int index)
        {
            Pages[index].OnEnd.AddListener(PageEndCallback);

            Pages[index].Begin();
        }

        private void PageEndCallback()
        {
            Pages[index].OnEnd.RemoveListener(PageEndCallback);

            Next();
        }

        public void Next()
        {
            index++;

            if(index >= Pages.Count)
            {
                End();
            }
            else
            {
                Pages[index - 1].Visible = false;

                Begin(index);
            }
        }

        public event Action OnEnd;
        void End()
        {
            OnEnd?.Invoke();
        }
    }
}