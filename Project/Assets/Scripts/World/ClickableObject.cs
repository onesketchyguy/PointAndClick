using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.UI;

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

        public string defaultOutPut = "I can't do that...";

        public Interaction[] interactions;

        private CutSceneManager cutSceneManager;

        private void OnValidate()
        {
            if (Item != null && spriteRenderer != null)
            {
                spriteRenderer.sprite = Item.sprite;

                gameObject.name = Item.name;
            }
        }

        private void Start()
        {
            startScale = transform.localScale;

            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            if (Item != null && spriteRenderer != null)
            {
                spriteRenderer.sprite = Item.sprite;
                gameObject.name = Item.name;
            }

            popupManager = FindObjectOfType<PopupManager>();
            helpText = FindObjectOfType<HelpText>();
            cutSceneManager = FindObjectOfType<CutSceneManager>();
        }

        private void OnMouseOver()
        {
            transform.localScale = startScale * sizeMultiplier;

            if (Item != null)
                helpText.SetSelected(Item);
            else helpText.SetText(gameObject.name);
        }

        private void OnMouseExit()
        {
            transform.localScale = startScale;
            helpText.SetSelected(null);
        }

        private void OnMouseUpAsButton()
        {
            if (Item == null)
            {
                Use(InteractionManager.objectUsing);
            }
            else
            {
                if (InteractionManager.objectUsing != null)
                {
                    Use(InteractionManager.objectUsing);

                    return;
                }

                popupManager.DisplayObject(Item, gameObject);
            }
        }

        public void Use(WorldObject @object)
        {
            // Check to see the usage of this item
            for (int i = 0; i < interactions.Length; i++)
            {
                if (interactions[i].objectUsed == @object)
                {
                    interactions[i].Event.Invoke();

                    var output = interactions[i].GetOutput();

                    if (output != string.Empty)
                        cutSceneManager.DisplayMessage(output);

                    return;
                }
            }

            if (@object == null)

                cutSceneManager.DisplayMessage(defaultOutPut);
            else
                cutSceneManager.DisplayMessage(InteractionManager.GetFailedActionOutput(@object, gameObject));
        }
    }
}