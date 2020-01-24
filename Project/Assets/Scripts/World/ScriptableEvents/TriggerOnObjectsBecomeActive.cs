using UnityEngine;

namespace World.ScriptableEvents
{
    public class TriggerOnObjectsBecomeActive : MonoBehaviour
    {
        [Tooltip("The event to trigger on objects becoming active.")]
        public UnityEngine.Events.UnityEvent _event;

        [Tooltip("When all of these objects become active the event will be triggered.")]
        public GameObject[] objectsToTrack;

        [Tooltip("This will toggle the trigger event from on objects becoming active to objects becoming inactive.")]
        public bool invert = false;

        private bool triggered;

        private void Start() => _event.AddListener(() => triggered = true);

        private void Update()
        {
            if (!triggered)
            {
                bool allActive = true;
                bool allInactive = true;

                foreach (var item in objectsToTrack)
                {
                    if (item.activeSelf == false)
                        allActive = false;
                    else
                        allInactive = false;
                }

                if (allActive && invert == false)
                {
                    // trigger event
                    _event.Invoke();
                }
                else
                if (allInactive && invert == true)
                {
                    // trigger event
                    _event.Invoke();
                }
            }
            else
            {
                Destroy(this);
            }
        }
    }
}