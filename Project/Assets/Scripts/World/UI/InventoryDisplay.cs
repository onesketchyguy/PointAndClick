using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace World.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        public Inventory inventoryToDisplay;

        public GameObject itemPrefab;

        private void OnEnable()
        {
            inventoryToDisplay.itemsChangedCallback += UpdateItems;
            UpdateItems(inventoryToDisplay.items);
        }

        private void UpdateItems(WorldObject[] items)
        {
            // Destroy old items
            foreach (var item in GetComponentsInChildren<Transform>())
            {
                if (item == transform) continue;
                Destroy(item.gameObject);
            }

            if (items == null) return;

            // Update items
            foreach (var item in items)
            {
                CreateItem(item);
            }
        }

        private void CreateItem(WorldObject item)
        {
            var inventoryItem = Instantiate(itemPrefab, transform);
            inventoryItem.GetComponent<InventoryItem>().Init(item);
        }
    }
}