using UnityEngine;

public class Wall : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500f;
    void Start()
    {

    }


    void Update()
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z == -100)
        {
            rb.MovePosition(Vector3.forward * Time.deltaTime);
        }
    }
}
