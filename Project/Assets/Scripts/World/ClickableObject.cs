using UnityEngine;
using World.UI;

namespace World
{
    public class ClickableObject : MonoBehaviour
    {
        public WorldObject Item;

        public SpriteRenderer spriteRenderer;

        private ClickedObjectDisplayManager clickedObjectDisplay;
        private HelpText helpText;
        private CutSceneManager cutSceneManager;

        private Vector3 startScale;
        private float sizeMultiplier = 1.12f;

        public string defaultOutPut = "I can't do that...";

        public Interaction[] interactions;

        [Space]
        public UnityEngine.Events.UnityEvent OnPickupItemEvent;

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

            clickedObjectDisplay = GameManager.instance.clickedObjectDisplay;
            helpText = GameManager.instance.helpText;
            cutSceneManager = GameManager.instance.cutSceneManager;
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

                clickedObjectDisplay.DisplayObject(Item, gameObject);
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

        private void OnDestroy()
        {
            OnPickupItemEvent.Invoke();
        }
    }
}