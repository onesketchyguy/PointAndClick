using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private new Rigidbody2D rigidbody;

        public string Vertical = "Vertical";
        public string Horizontal = "Horizontal";

        public float speed = 5;

        internal bool facingRight = true;

        internal bool overrideFace = false;

        internal Vector2 input
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

            if (!overrideFace)
            {
                if (n_input.x > 0.1f)
                {
                    facingRight = true;
                }
                else
                if (n_input.x < -0.1f)
                {
                    facingRight = false;
                }
            }

            transform.localScale = new Vector3(facingRight ? 1 : -1, 1, 1);
        }
    }
}