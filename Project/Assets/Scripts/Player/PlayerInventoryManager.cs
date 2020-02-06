using UnityEngine;
using World;

namespace Player
{
    public class PlayerInventoryManager : Inventory
    {
        public GameObject arm;

        private bool usingCandle = true;

        public WorldObject candle;

        public static WorldObject[] _items;

        private void OnEnable()
        {
            if (!InteractionManager.canHoldWhileInteracting.Contains(candle))
            {
                InteractionManager.canHoldWhileInteracting.Add(candle);
            }

            if (_items != null)
                items = _items;

            if (itemsChangedCallback != null)
                itemsChangedCallback.Invoke(_items);
            itemsChangedCallback += UpdateItems;
        }

        private void LateUpdate()
        {
            arm.SetActive(usingCandle);

            if (!contains(InteractionManager.objectUsing))
            {
                InteractionManager.objectUsing = null;
            }

            usingCandle = contains(candle) && InteractionManager.objectUsing == candle;
        }

        public void UpdateItems(WorldObject[] items)
        {
            _items = items;
        }
    }
}