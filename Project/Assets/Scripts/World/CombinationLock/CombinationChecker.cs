using System.Collections.Generic;
using UnityEngine;

namespace World.CombinationLock
{
    public class CombinationChecker : MonoBehaviour
    {
        public Combination combination;

        public GameObject numberObjectPrefab;

        public Transform numberObjectParent;

        private List<NumberObject> numberObjects = new List<NumberObject>();

        public System.Action onCompletedAction;

        private void OnEnable()
        {
            GameManager.inMenu = true;
        }

        private void OnDisable()
        {
            GameManager.inMenu = false;
        }

        private void OnValidate()
        {
            combination.validate();
        }

        private void Start()
        {
            if (numberObjectParent == null) numberObjectParent = transform;

            for (int i = 0; i < 4; i++)
            {
                var go = Instantiate(numberObjectPrefab, numberObjectParent);
                numberObjects.Add(go.GetComponent<NumberObject>());
            }
        }

        public void TryLock()
        {
            var a = numberObjects[0].GetNumber();
            var b = numberObjects[1].GetNumber();
            var c = numberObjects[2].GetNumber();
            var d = numberObjects[3].GetNumber();

            if (combination.CheckCombination(a, b, c, d) == true)
            {
                // Unlocked!
                onCompletedAction.Invoke();
                onCompletedAction = null;
            }
        }
    }

    [System.Serializable]
    public class Combination
    {
        public byte a, b, c, d;

        public bool CheckCombination(byte a, byte b, byte c, byte d)
        {
            return (this.a == a && this.b == b && this.c == c && this.d == d);
        }

        public void validate()
        {
            a %= 10;
            b %= 10;
            c %= 10;
            d %= 10;
        }
    }
}