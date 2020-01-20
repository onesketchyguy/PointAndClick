using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.ScriptableEvents
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerEvent : MonoBehaviour
    {
        public bool OneOff = true;

        public UnityEngine.Events.UnityEvent Event;

        private void OnValidate()
        {
            var col = GetComponent<Collider2D>();
            if (col != null)
            {
                col.isTrigger = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                // Trigger the event
                Event.Invoke();

                if (OneOff)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}