using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.ScriptableEvents
{
    public class MovingObject : MonoBehaviour
    {
        public Vector2[] points;
        public float speed = 5;

        public float stoppingDistance = 1.5f;

        public bool disapearOnFinish;

        private Vector3 startPos;

        private new SpriteRenderer renderer;

        private void Start()
        {
            startPos = transform.position;

            renderer = GetComponent<SpriteRenderer>();

            renderer.enabled = false;
        }

        public void Begin()
        {
            StartCoroutine(Move());
        }

        private void OnDrawGizmosSelected()
        {
            if (points == null || points.Length <= 0)
                return;

            Gizmos.color = Color.red;
            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i];

                Gizmos.DrawSphere((Vector2)transform.position + point, 0.25f);
            }
        }

        private IEnumerator Move()
        {
            renderer.enabled = true;

            yield return null;

            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i] + (Vector2)startPos;

                while (true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);

                    if (Vector2.Distance(transform.position, point) < stoppingDistance)
                        break;

                    yield return null;
                }

                yield return null;
            }

            if (disapearOnFinish)
            {
                Destroy(gameObject);
            }
        }
    }
}