using UnityEngine;

public class PlayerMowement : MonoBehaviour
{
    private Rigidbody rb;
    public Scene gm;
    [SerializeField]
    private float strafeSpeed;
    [SerializeField]
    private float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gm.EndGame();
            Debug.Log("�����");
        }
    }
    public void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown)
        {

            if (Event.current.keyCode == KeyCode.A)
            {
                rb.AddForce(Vector3.left * 5, ForceMode.VelocityChange);
            }
            if (Event.current.keyCode == KeyCode.D)
            {
                rb.AddForce(Vector3.right * 5, ForceMode.VelocityChange);
            }
            if (Event.current.keyCode == KeyCode.W)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            if (transform.position.y < -5f)
            {
                gm.EndGame();
                Debug.Log("�����");
            }
        }
    }
}
