using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class HelpText : MonoBehaviour
    {
        private Text textObject;

        private void Start()
        {
            textObject = GetComponent<Text>();
            textObject.text = "";
        }

        public void SetSelected(WorldObject obj)
        {
            if (obj == null)
            {
                textObject.text = "";
                return;
            }

            textObject.text = $"{obj.name}\n";
        }

        public void SetText(string n_text)
        {
            textObject.text = n_text;
        }

        private void Update()
        {
            transform.position = Utility.Utilities.GetMousePosition();
        }
    }
}