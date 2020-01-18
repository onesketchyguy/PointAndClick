using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private new Rigidbody2D rigidbody;

        public string Vertical = "Vertical";
        public string Horizontal = "Horizontal";

        public float speed = 5;

        private Vector2 input
        {
            get
            {
                return new Vector2()
                {
                    x = Input.GetAxis(Horizontal),
                    y = Input.GetAxis(Vertical)
                };
            }
        }

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var n_input = input;
            n_input.y *= 0.5f;

            rigidbody.MovePosition((Vector2)transform.position + ((n_input * speed) * Time.deltaTime));
        }
    }
}