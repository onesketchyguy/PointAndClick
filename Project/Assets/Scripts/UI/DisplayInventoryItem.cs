using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class DisplayInventoryItem : MonoBehaviour
    {
        public Text helpText;
        public Image image;

        public void Init(WorldObject obj)
        {
            image.sprite = obj.sprite;
            helpText.text = $"{obj.name}\n" +
                            $"{obj.description}";

            HideText();
        }

        public void HideText()
        {
            helpText.gameObject.SetActive(false);
        }

        public void ShowText()
        {
            helpText.gameObject.SetActive(true);
        }
    }
}