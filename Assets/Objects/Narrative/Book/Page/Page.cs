using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative
{
	public class Page : MonoBehaviour
	{
        Book book;
        int index;
        public void Init(Book book)
        {
            this.book = book;

            index = book.Pages.IndexOf(this);
        }

		public void Begin()
        {
            book.Animator.Play("Page " + (index + 1));

            End();
        }

        public event Action OnEnd;
        protected void End()
        {
            OnEnd?.Invoke();
        }
	}
}