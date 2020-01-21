using UnityEngine;

namespace World.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        public Inventory inventoryToDisplay;

        public GameObject itemPrefab;

        /// <summary>
        /// Wether or not the items in this inventory should be taken or used
        /// </summary>
        internal bool Take;

        private void OnEnable()
        {
            if (inventoryToDisplay == null) return;
            Initialize(inventoryToDisplay);
        }

        public void Hide()
        {
            DestroyItems();
        }

        public void Initialize(Inventory inventory)
        {
            inventory.itemsChangedCallback = null;
            inventory.itemsChangedCallback += UpdateItems;
            UpdateItems(inventory.items);

            inventoryToDisplay = inventory;
        }

        private void UpdateItems(WorldObject[] items)
        {
            // Destroy old items
            DestroyItems();

            if (items == null) return;

            // Update items
            foreach (var item in items)
            {
                CreateItem(item);
            }
        }

        private void DestroyItems()
        {
            foreach (var item in GetComponentsInChildren<Transform>())
            {
                if (item == transform) continue;
                Destroy(item.gameObject);
            }
        }

        private void CreateItem(WorldObject item)
        {
            var inventoryItem = Instantiate(itemPrefab, transform);
            var invItem = inventoryItem.GetComponent<InventoryItem>();

            invItem.Init(item);
            invItem.canTakeItem = Take;
        }
    }
}