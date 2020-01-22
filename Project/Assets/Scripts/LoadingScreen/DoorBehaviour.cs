using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loading
{
    public class DoorBehaviour : MonoBehaviour
    {
        public float maxDistance = 5;

        private void OnEnable()
        {
            var pos = transform.position;

            while (Utility.Utilities.OffScreen(pos) == false)
                pos.x = Random.Range(-maxDistance, maxDistance);

            transform.position = pos;
        }

        private void Update()
        {
            var pos = transform.position;

            pos.x -= Input.GetAxis("Horizontal") * maxDistance * Time.deltaTime;

            if (pos.x > maxDistance)
                pos.x = -maxDistance;
            else
            if (pos.x < -maxDistance)
                pos.x = maxDistance;

            transform.position = pos;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(-maxDistance, 0), new Vector3(maxDistance, 0));
        }
    }
}