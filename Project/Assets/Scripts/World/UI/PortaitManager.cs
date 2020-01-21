using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class PortaitManager : MonoBehaviour
    {
        public Text textObject;

        public void DisplayMessage(string message)
        {
            StopAllCoroutines();
            StartCoroutine(DisplayText(message));
        }

        public IEnumerator DisplayText(string message)
        {
            textObject.text = "";

            float time = Time.time;

            yield return null;

            var _chars = message.ToCharArray();

            for (int i = 0; i < _chars.Length; i++)
            {
                textObject.text += _chars[i];

                time += Time.deltaTime * 15;

                yield return new WaitForSecondsRealtime(Time.deltaTime);
            }

            yield return new WaitForSecondsRealtime(time);

            GameManager.instance.cutSceneManager.HideMessage();
        }
    }
}