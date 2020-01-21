using UnityEngine;
using World.UI;

namespace World
{
    public class SearchableObject : Inventory
    {
        private Vector3 startScale;
        private float sizeMultiplier = 1.12f;

        private HelpText helpText;
        private CutSceneManager cutSceneManager;

        public bool locked;

        public void SetLocked(bool val) => locked = val;

        private InventoryDisplay inventoryDisplay;

        private void Start()
        {
            startScale = transform.localScale;

            var displays = FindObjectsOfType<InventoryDisplay>();

            for (int i = 0; i < displays.Length; i++)
            {
                if (displays[i].inventoryToDisplay == null)
                {
                    inventoryDisplay = displays[i];
                    break;
                }
            }

            helpText = FindObjectOfType<HelpText>();
            cutSceneManager = FindObjectOfType<CutSceneManager>();
        }

        private void OnMouseOver()
        {
            if (GameManager.inMenu) return;

            if (items == null || items.Length == 0)
            {
                // Remove this component
                Destroy(this);

                return;
            }

            transform.localScale = startScale * sizeMultiplier;

            helpText.SetText($"{gameObject.name} {(locked ? "(LOCKED)" : "")}");
        }

        private void OnMouseExit()
        {
            if (GameManager.inMenu) return;

            transform.localScale = startScale;
            helpText.SetSelected(null);
        }

        private bool open;

        private void OnMouseUpAsButton()
        {
            if (GameManager.inMenu) return;

            if (locked)
            {
                // Do nothing
                //cutSceneManager.DisplayMessage("It's locked.");

                GetComponent<CombinationLock.CombinationLock>().OpenMenu();
            }
            else
            {
                if (open == false)
                {
                    // Open inventory
                    inventoryDisplay.Initialize(this);
                }
                else
                {
                    inventoryDisplay.Hide();
                }

                open = !open;
            }
        }
    }
}