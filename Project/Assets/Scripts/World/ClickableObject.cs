using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class ClickableObject : MonoBehaviour
    {
        private Vector3 startScale;

        public WorldObject Item;

        public SpriteRenderer spriteRenderer;

        private UI.PopupManager popupManager;

        private UI.HelpText helpText;

        private float sizeMultiplier = 1.12f;

        private void OnValidate()
        {
            if (Item != null && spriteRenderer != null)
            {
                spriteRenderer.sprite = Item.sprite;
            }
        }

        private void Start()
        {
            startScale = transform.localScale;

            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            spriteRenderer.sprite = Item.sprite;
            gameObject.name = Item.name;

            popupManager = FindObjectOfType<UI.PopupManager>();
            helpText = FindObjectOfType<UI.HelpText>();
        }

        private void OnMouseOver()
        {
            transform.localScale = startScale * sizeMultiplier;

            helpText.SetSelected(Item);
        }

        private void OnMouseExit()
        {
            transform.localScale = startScale;
            helpText.SetSelected(null);
        }

        private void OnMouseUpAsButton()
        {
            popupManager.DisplayObject(Item, gameObject);
        }
    }
}