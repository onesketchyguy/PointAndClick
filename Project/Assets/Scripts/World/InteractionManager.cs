using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace World
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

        public static string GetFailedActionOutput(WorldObject attemptedToUse, GameObject usedWith)
        {
            var item = attemptedToUse.name.ToLower();
            var obj = usedWith.name.ToLower();

            var strings = new string[]
            {
                $"I can't use a {item} with a {obj}.",
                "What?", "How am I supposed to do that?", "You're kidding right?",
                $"This is a {obj}... How am I supposed to do that?",
                $"I don't think a {item} is supposed to do that.",
                $"I don't think a {item} goes here.",
                $"What am I supposed to with with this?"
            };

            return strings[Random.Range(0, strings.Length - 1)];
        }
    }

    [System.Serializable]
    public class Interaction
    {
        public UnityEngine.Events.UnityEvent Event;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2235:Mark all non-serializable fields", Justification = "<Pending>")]
        public WorldObject objectUsed;

        public string output = "Nothing happens...";

        public string GetOutput()
        {
            var r = output;

            if (output.Contains("[item]"))
            {
                r.Replace("[item]", objectUsed.name.ToLower());

                var front = r.Split('[').FirstOrDefault();
                var back = r.Split(']').LastOrDefault();

                r = "";

                r += front;
                r += objectUsed.name.ToLower();
                r += back;
            }

            return r;
        }
    }
}