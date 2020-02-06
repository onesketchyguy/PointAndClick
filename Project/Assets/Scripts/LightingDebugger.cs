using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

namespace Debugging
{
    public class LightingDebugger : MonoBehaviour
    {
        public Light2D globalLighting;
        public Light2D debugLighting;

        public bool debug;

        private void OnValidate()
        {
            if (globalLighting != null && debugLighting != null)
            {
                if (debug)
                {
                    globalLighting.gameObject.SetActive(false);

                    debugLighting.gameObject.SetActive(true);
                }
                else
                {
                    debugLighting.gameObject.SetActive(false);

                    globalLighting.gameObject.SetActive(true);
                }
            }
        }

        private void Start()
        {
            if (globalLighting != null)
                while (globalLighting.gameObject.activeSelf == false)
                {
                    if (debugLighting != null)
                        debugLighting.gameObject.SetActive(false);
                    globalLighting.gameObject.SetActive(debugLighting != null && debugLighting.gameObject.activeSelf == false);
                }
        }
    }
}