using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform objectFollowing;

    [Header("Freeze")]
    public bool x;

    public bool y = true, z = true;

    public float speed = 7.5f;

    private void Start()
    {
        if (objectFollowing == null)
        {
            objectFollowing = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (objectFollowing != null)
        {
            var pos = objectFollowing.position;

            if (x) pos.x = transform.position.x;
            if (y) pos.y = transform.position.y;
            if (z) pos.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        }
    }
}