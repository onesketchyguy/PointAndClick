using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerArm : MonoBehaviour
    {
        public GameObject Arm;

        public PlayerMovement move;

        private void Update()
        {
            // Follow the mouse
            var mouse = Utility.Utilities.GetMousePosition();

            LookAtPosition(Arm, mouse);

            if (mouse.x > move.transform.position.x && !move.facingRight)
            {
                move.overrideFace = true;
                move.facingRight = true;
            }
            else
            if (mouse.x < move.transform.position.x && move.facingRight)
            {
                move.overrideFace = true;
                move.facingRight = false;
            }
            else
            {
                if (move.input == Vector2.zero && move.overrideFace == true)
                    move.overrideFace = false;
            }
        }

        private void LookAtPosition(GameObject follower, Vector3 followPosition)
        {
            // Get direction you want to point at
            var direction = ((Vector2)followPosition - (Vector2)follower.transform.position).normalized;
            // Set vector of transform directly
            follower.transform.up = direction;
        }
    }
}