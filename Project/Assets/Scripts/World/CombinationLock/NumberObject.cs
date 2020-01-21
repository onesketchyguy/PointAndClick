using UnityEngine;

namespace World.CombinationLock
{
    public class NumberObject : MonoBehaviour
    {
        public UnityEngine.UI.Text text;

        private int number = 0;

        private void Start()
        {
            ModifyNumber(Random.Range(0, 10));
        }

        public void ModifyNumber(int modVal)
        {
            number += modVal;

            if (number <= -1) number = 9;

            number %= 10;

            text.text = number.ToString();
        }

        public byte GetNumber()
        {
            return (byte)number;
        }
    }
}