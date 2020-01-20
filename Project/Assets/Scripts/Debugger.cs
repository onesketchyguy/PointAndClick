using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Debugger : MonoBehaviour
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
        while (globalLighting.gameObject.activeSelf == false)
        {
            debugLighting.gameObject.SetActive(false);
            globalLighting.gameObject.SetActive(debugLighting.gameObject.activeSelf == false);
        }
    }
}