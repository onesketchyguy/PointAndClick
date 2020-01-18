using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class PopupManager : MonoBehaviour
    {
        public GameObject clickedObjectDisplay;

        public Text clickedObjectText;
        public Image clickedObjectImage;

        private void Start()
        {
            HideObject();
        }

        public void DisplayObject(World.WorldObject obj)
        {
            clickedObjectImage.sprite = obj.sprite;
            clickedObjectText.text = $"{obj.name}\n" +
                                     $"{obj.description}";

            clickedObjectDisplay.SetActive(true);
        }

        public void HideObject()
        {
            clickedObjectDisplay.SetActive(false);

            clickedObjectImage.sprite = null;
            clickedObjectText.text = "";
        }
    }
}