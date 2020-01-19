using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerArm : MonoBehaviour
    {
        public GameObject LowerArm;
        public GameObject UpperArm;

        private void Update()
        {
            // Follow the mouse
            var mouse = Utility.Utilities.GetMousePosition();

            float dist = 0.3f;

            LookAtPosition(UpperArm, LowerArm.transform.position);
            LookAtPosition(LowerArm, mouse);

            mouse.x = Mathf.Clamp(mouse.x, transform.position.x - dist, transform.position.x + dist);
            mouse.y = Mathf.Clamp(mouse.y, transform.position.y - (dist / 2), transform.position.y + (dist / 2));
            mouse.z = 0;

            FollowPos(LowerArm, mouse);
        }

        private void LookAtPosition(GameObject follower, Vector3 followPosition)
        {
            // Get direction you want to point at
            var direction = ((Vector2)followPosition - (Vector2)follower.transform.position).normalized;
            // Set vector of transform directly
            follower.transform.up = direction;
        }

        private void FollowPos(GameObject follower, Vector3 followPosition)
        {
            follower.transform.position = (followPosition);
        }
    }
}