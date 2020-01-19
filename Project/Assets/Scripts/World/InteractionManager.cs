using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.UI
{
    public class InteractionManager : MonoBehaviour
    {
        private static WorldObject _object;

        public static WorldObject objectUsing
        {
            get
            {
                return _object;
            }
            set
            {
                if (onUsingUpdate != null)
                {
                    onUsingUpdate.Invoke(value);
                }

                _object = value;
            }
        }

        public delegate void UsingUpdated(WorldObject objectUsing);

        public static UsingUpdated onUsingUpdate;
    }

    [System.Serializable]
    public class Interaction
    {
        public UnityEngine.Events.UnityEvent Event;
        public WorldObject objectUsed;

        public string output = "Nothing happens...";
    }
}