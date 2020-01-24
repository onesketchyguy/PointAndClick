using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Effects
{
    public class ScaleWithCameraDistance : MonoBehaviour
    {
        private float distanceFromCamera;
        private float currentDistance;

        private void Start()
        {
            distanceFromCamera = transform.position.y - Utility.Utilities.ScreenMin.y;
        }

        private void LateUpdate()
        {
            currentDistance = transform.position.y - Utility.Utilities.ScreenMin.y;

            var scale = 1 - ((currentDistance - distanceFromCamera) / currentDistance);

            var oldscale = transform.localScale * scale;

            transform.localScale = oldscale;
        }
    }
}