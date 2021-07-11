using UnityEngine;

public class PlayerMowement : MonoBehaviour
{
    public Rigidbody rb;
    public Scene gm;
    [SerializeField]
    private float speed = 500f;
    [SerializeField]
    private float strafeSpeed = 500f;
    [SerializeField]
    private float jumpForce = 15f;

    protected bool doJump = false;
    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool moveForvard = false;
    protected bool moveBackvard = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            gm.EndGame();
            Debug.Log("Конец");
        }
    }
    void Update()
    {
        if (Input.GetKey("s"))
        {
            moveBackvard = true;
        }
        else
        {
            moveBackvard = false;
        }
        if (Input.GetKey("w"))
        {
            moveForvard = true;
        }
        else
        {
            moveForvard = false;
        }
        if (Input.GetKey("a"))
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }

        if (Input.GetKey("d"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }

        if (Input.GetKey("space"))
        {
            doJump = true;
        }
        else
        {
            doJump = false;
        }

        if (transform.position.y < -5f)
        {
            gm.EndGame();
            Debug.Log("Конец");
        }
    }
    private void FixedUpdate()
    {
        if (moveForvard)
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (moveBackvard)
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (strafeLeft)
        {
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (strafeRight)
        {
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}
