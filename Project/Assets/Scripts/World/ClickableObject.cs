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

        private bool dontRead
        {
            get
            {
                return (GameManager.inMenu || enabled == false);
            }
        }

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
                if (Player.PlayerInventoryManager._items != null && Player.PlayerInventoryManager._items.Length > 0)
                    foreach (var item in Player.PlayerInventoryManager._items)
                    {
                        if (item == Item && Item.canBePickedUp)
                        {
                            Destroy(gameObject);

                            return;
                        }
                    }

                spriteRenderer.sprite = Item.sprite;
                gameObject.name = Item.name;
            }

            clickedObjectDisplay = GameManager.instance.clickedObjectDisplay;
            helpText = GameManager.instance.helpText;
            cutSceneManager = GameManager.instance.cutSceneManager;
        }

        private void OnMouseOver()
        {
            if (dontRead) return;

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
            if (dontRead) return;

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

                if (Item.canBePickedUp)
                    clickedObjectDisplay.DisplayObject(Item, gameObject);
                else
                {
                    cutSceneManager.DisplayMessage(Item.description);
                }
            }
        }

        public void Use(WorldObject @object)
        {
            // Check to see the usage of this item
            for (int i = 0; i < interactions.Length; i++)
            {
                if (interactions[i].objectUsed == @object || (interactions[i].objectUsed == null && InteractionManager.canHoldWhileInteracting.Contains(@object)))
                {
                    var output = interactions[i].GetOutput();

                    if (output != string.Empty)
                    {
                        cutSceneManager.DisplayMessage(output);
                    }

                    interactions[i].Event.Invoke();

                    return;
                }
            }

            if (@object == null || InteractionManager.canHoldWhileInteracting.Contains(@object))
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