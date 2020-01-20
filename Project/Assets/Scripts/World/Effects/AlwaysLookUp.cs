using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Effects
{
    public class AlwaysLookUp : MonoBehaviour
    {
        private Vector3 up
        {
            get
            {
                var val = Vector3.up;

                if (transform.parent != null)
                {
                    var parentPos = transform.parent.up;

                    // Use the up in between global up and parent up
                    val = (Vector3.up + parentPos) / 2f;
                }

                return val;
            }
        }

        private void Update()
        {
            transform.up = up;
        }
    }
}