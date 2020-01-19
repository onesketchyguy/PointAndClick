using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class InventoryItem : MonoBehaviour
    {
        public Image image;

        public string helpText;

        private HelpText helpTextManager;

        public WorldObject Item;

        private Vector3 scale;

        private void Start()
        {
            scale = GetComponent<RectTransform>().localScale;

            InteractionManager.onUsingUpdate += UpdateThis;
        }

        private void UpdateThis(WorldObject currentSelected)
        {
            if (currentSelected != Item)
            {
                GetComponent<RectTransform>().localScale = scale;
            }
            else
            {
                GetComponent<RectTransform>().localScale = scale + Vector3.one * 0.25f;
            }
        }

        private void OnDestroy()
        {
            InteractionManager.onUsingUpdate -= UpdateThis;
        }

        public void Clicked()
        {
            if (InteractionManager.objectUsing == Item)
            {
                InteractionManager.objectUsing = null;
            }
            else
            {
                InteractionManager.objectUsing = Item;
            }
        }

        public void SetHelpText()
        {
            helpTextManager.SetText(helpText);
        }

        public void HideHelpText()
        {
            helpTextManager.SetText("");
        }

        public void Init(WorldObject obj)
        {
            image.sprite = obj.sprite;
            helpText = $"{obj.name}\n" +
                       $"{obj.description}";

            helpTextManager = FindObjectOfType<HelpText>();

            Item = obj;
        }
    }
}