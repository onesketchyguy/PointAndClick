using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.UI;

namespace World
{
    public class Inventory : MonoBehaviour
    {
        public WorldObject[] items;

        public delegate void OnItemsChangedCallback(WorldObject[] newItems);

        public OnItemsChangedCallback itemsChangedCallback;

        public void Add(WorldObject obj)
        {
            if (items == null || items.Length == 0)
            {
                items = new WorldObject[1];
            }
            else
            {
                var oldItems = items;
                items = new WorldObject[oldItems.Length + 1];

                for (int i = 0; i < oldItems.Length; i++)
                {
                    items[i] = oldItems[i];
                }
            }

            items[items.Length - 1] = obj;

            if (itemsChangedCallback != null)
                itemsChangedCallback.Invoke(items);
        }

        public void Remove(WorldObject obj)
        {
            if (InteractionManager.objectUsing == obj)
                InteractionManager.objectUsing = null;

            if (items == null || items.Length == 0)
            {
                Debug.LogError($"Inventory empty! Unable to complete action!");
                return;
            }
            else
            {
                if (items.Length == 1)
                {
                    items = null;
                }
                else
                {
                    var oldItems = items;
                    items = new WorldObject[items.Length - 1];

                    var index = 0;
                    for (int i = 0; i < items.Length; i++)
                    {
                        index++;
                        var item = oldItems[i];

                        if (item.name == obj.name && item.description == obj.description)
                        {
                            // This is the correct item remove this
                            index--;
                        }

                        items[i] = oldItems[index];
                    }
                }
            }

            if (itemsChangedCallback != null)
                itemsChangedCallback.Invoke(items);
        }
    }
}