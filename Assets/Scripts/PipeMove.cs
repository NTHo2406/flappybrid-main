using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}