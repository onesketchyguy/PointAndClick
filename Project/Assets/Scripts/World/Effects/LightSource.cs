using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

namespace World.Effects
{
    public class LightSource : MonoBehaviour
    {
        public bool LightsOn = true;

        internal bool on
        {
            get
            {
                return lights.FirstOrDefault().enabled;
            }
            set
            {
                SetLights(value);
            }
        }

        public Light2D[] lights;

        private void OnValidate()
        {
            if (lights == null)
                lights = GetComponentsInChildren<Light2D>();

            on = LightsOn;
        }

        public void ToggleLights()
        {
            var toggle = !on;

            foreach (var light in lights)
            {
                light.enabled = toggle;
            }
        }

        public void SetLights(bool toggle)
        {
            foreach (var light in lights)
            {
                light.enabled = toggle;
            }
        }
    }
}