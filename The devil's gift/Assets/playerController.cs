using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private bool lookRight;

    private int jumpCount;

    public int jumpNumber;
    public int health;

    public float speed;
    public float jumpForce;
    public float moveInputH;
    public float moveInputV;
    public float checkRadius;

    public Transform graundCheck;

    public LayerMask whatIsGraund;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            jumpCount--;
        }


        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void FixedUpdate()
    {
        moveInputH = Input.GetAxis("Horizontal");
        moveInputV = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(moveInputV * speed, rb.linearVelocity.y);
        rb.linearVelocity = new Vector2(moveInputH * speed, rb.linearVelocity.x);

        if (lookRight == true && moveInputH > 0)
        {
            FlipIt();
        }
        else if (lookRight == false && moveInputH < 0)
        {
            FlipIt();
        }
    }

    private void FlipIt()
    {
        lookRight = !lookRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
