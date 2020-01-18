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

        private void Start()
        {
            startScale = transform.localScale;

            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            spriteRenderer.sprite = Item.sprite;
            gameObject.name = Item.name;

            popupManager = FindObjectOfType<UI.PopupManager>();
        }

        private void OnMouseOver()
        {
            transform.localScale = startScale * 1.25f;
        }

        private void OnMouseExit()
        {
            transform.localScale = startScale;
        }

        private void OnMouseUpAsButton()
        {
            popupManager.DisplayObject(Item, gameObject);
        }
    }
}