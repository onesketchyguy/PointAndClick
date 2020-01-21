using UnityEngine;

namespace World
{
    public class Chase : MonoBehaviour
    {
        public float speed = 5;
        public Transform toChase;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, toChase.position, speed * Time.deltaTime);
        }
    }
}