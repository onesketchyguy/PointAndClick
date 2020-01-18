using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    public class ClickableObject : MonoBehaviour
    {
        private Vector3 startScale, startPosition;

        public WorldObject Item;

        public SpriteRenderer spriteRenderer;

        private void Start()
        {
            startPosition = transform.position;
            startScale = transform.localScale;

            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            spriteRenderer.sprite = Item.sprite;
            gameObject.name = Item.name;
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
            FindObjectOfType<UI.PopupManager>().DisplayObject(Item);
        }
    }
}