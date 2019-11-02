using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game
{
    public class PointerClickEvent : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent _event;

        public void OnPointerClick(PointerEventData eventData)
        {
            _event.Invoke();
        }
    }
}