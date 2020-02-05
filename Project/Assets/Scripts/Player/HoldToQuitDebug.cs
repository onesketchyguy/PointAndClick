using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldToQuitDebug : MonoBehaviour
{
    private float held;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) held += Time.deltaTime; else held = 0;

        if (held >= 3)
        {
            Application.Quit();
        }
    }
}