using System.Linq;
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
            if (n_text.Contains("//"))
            {
                n_text = n_text.Split('/').FirstOrDefault();
            }

            textObject.text = n_text;
        }

        private void Update()
        {
            transform.position = Utility.Utilities.GetMousePosition();
        }
    }
}