using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.UI
{
    public class InteractionManager : MonoBehaviour
    {
        public static WorldObject objectUsing;
    }

    [System.Serializable]
    public class Interaction
    {
        public UnityEngine.Events.UnityEvent Event;
        public WorldObject objectUsed;

        public string output = "Nothing happens...";
    }
}