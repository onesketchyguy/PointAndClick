using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loading
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DoEventOnClick : MonoBehaviour
    {
        public UnityEngine.Events.UnityEvent _event;

        private void OnMouseUpAsButton()
        {
            _event.Invoke();
        }
    }
}