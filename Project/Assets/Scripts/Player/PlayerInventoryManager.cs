using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World;

namespace Player
{
    public class PlayerInventoryManager : Inventory
    {
        public GameObject arm;

        private bool usingCandle = true;

        public WorldObject candle;

        private void Update()
        {
            arm.SetActive(usingCandle);

            usingCandle = contains(candle);
        }
    }
}