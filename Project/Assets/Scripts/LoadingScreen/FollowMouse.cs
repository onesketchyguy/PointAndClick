using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loading
{
    public class FollowMouse : MonoBehaviour
    {
        public Transform objectToFollowMouse;

        private void Start()
        {
            if (objectToFollowMouse == null)
                objectToFollowMouse = transform;
        }

        private void Update()
        {
            var mousePos = (Vector2)Utility.Utilities.GetMousePosition();

            objectToFollowMouse.position = Vector3.Lerp(objectToFollowMouse.position, mousePos, (Vector2.Distance(objectToFollowMouse.position, mousePos) * Time.deltaTime) + Time.deltaTime);
        }
    }
}