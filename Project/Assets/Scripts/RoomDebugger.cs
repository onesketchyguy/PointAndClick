using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Debugging
{
    public class RoomDebugger : MonoBehaviour
    {
        public Text roomText;

        public bool debug;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F3)) debug = !debug;

            if (debug)
                roomText.text = $"Active room: {SceneManager.GetActiveScene().name}";
            else roomText.text = "";
        }
    }
}