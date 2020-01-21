using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class PortaitManager : MonoBehaviour
    {
        public Text textObject;
        public Image portrait;

        public void DisplayMessage(string message)
        {
            StartCoroutine(DisplayText(message));
        }

        public IEnumerator DisplayText(string message)
        {
            textObject.text = "";

            yield return null;

            var _chars = message.ToCharArray();

            for (int i = 0; i < _chars.Length; i++)
            {
                textObject.text += _chars[i];

                yield return null;
            }
        }
    }
}