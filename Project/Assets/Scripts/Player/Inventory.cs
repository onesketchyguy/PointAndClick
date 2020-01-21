using UnityEngine;

namespace World
{
    public class Inventory : MonoBehaviour
    {
        public WorldObject[] items;

        public delegate void OnItemsChangedCallback(WorldObject[] newItems);

        public OnItemsChangedCallback itemsChangedCallback;

        public bool contains(WorldObject obj)
        {
            if (items != null && items.Length > 0)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == obj)
                        return true;
                }
            }

            return false;
        }

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

        public void Remove(WorldObject @object)
        {
            if (InteractionManager.objectUsing == @object)
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

                    var y = -1;
                    for (int i = 0; i < oldItems.Length; i++)
                    {
                        if (oldItems[i] == @object)
                        {
                            continue;
                        }

                        y++;

                        items[y] = oldItems[i];
                    }
                }
            }

            if (itemsChangedCallback != null)
                itemsChangedCallback.Invoke(items);
        }
    }
}