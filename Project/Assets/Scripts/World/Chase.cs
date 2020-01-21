using UnityEngine;

namespace World
{
    public class Chase : MonoBehaviour
    {
        public float speed = 5;
        public Transform toChase;

        [Tooltip("Amount of time this will wait before pouncing after catching up to the object chasing.")]
        public float delayBeforePounce = 1.5f;

        private float waited;

        public float stoppingDistance = 2;

        private void Update()
        {
            if (Vector3.Distance(transform.position, toChase.position) > stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, toChase.position, speed * Time.deltaTime);
            }
            else
            {
                if (waited >= delayBeforePounce)
                {
                    transform.position = Vector3.MoveTowards(transform.position, toChase.position, (speed * 3) * Time.deltaTime);
                }
                else
                {
                    waited += Time.deltaTime;
                }
            }
        }
    }
}