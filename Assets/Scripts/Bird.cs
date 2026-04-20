using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        RotateBird();
    }

    void RotateBird()
    {
        float angle = rb.velocity.y * 5f;
        angle = Mathf.Clamp(angle, -90f, 30f);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, angle),
            rotationSpeed * Time.deltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;
        GameManager.instance.GameOver();
    }
}