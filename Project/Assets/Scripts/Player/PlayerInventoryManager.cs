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

        private void Start()
        {
            if (_items != null)
            {
                items = _items;
            }

            itemsChangedCallback.Invoke(_items);
            itemsChangedCallback += UpdateItems;
        }

        private void Update()
        {
            arm.SetActive(usingCandle);

            usingCandle = contains(candle) && InteractionManager.objectUsing == candle;
        }

        public void UpdateItems(WorldObject[] items)
        {
            _items = items;
        }
    }
}