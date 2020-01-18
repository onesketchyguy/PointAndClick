using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World
{
    [CreateAssetMenu(fileName = "New item", menuName = "World Item")]
    public class WorldObject : ScriptableObject
    {
        public Sprite sprite;
        public new string name = "New item";
        public string description = "A stock description for a new item.";
    }
}