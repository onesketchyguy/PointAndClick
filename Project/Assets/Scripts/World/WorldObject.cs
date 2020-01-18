using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    [CreateAssetMenu(fileName = "New item", menuName = "World Item")]
    public class WorldObject : ScriptableObject
    {
        public Sprite sprite;
        public string description = "A stock description for a new item.";

        public bool canBePickedUp = true;

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}