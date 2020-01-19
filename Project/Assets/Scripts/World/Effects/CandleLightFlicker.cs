using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

namespace World.Effects
{
    public class CandleLightFlicker : MonoBehaviour
    {
        public Light2D light2D;

        public float flickerSpeed = 0.35f;

        public Gradient colors;

        private float currentStep;

        private void Update()
        {
            if (light2D == null)
            {
                Debug.LogError($"No light2D assigned to {gameObject.name}!");
                Destroy(this);

                return;
            }

            var pingPong = Mathf.PingPong(Time.time, flickerSpeed) / flickerSpeed;
            currentStep = pingPong;

            light2D.color = Color.Lerp(light2D.color, colors.Evaluate(currentStep), pingPong);
        }
    }
}