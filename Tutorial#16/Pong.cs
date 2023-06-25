using UnityEngine;

public class Pong : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField] float angle = 45 * Mathf.Deg2Rad;

    Vector2 v2;

    void Update()
    {
        float y = Mathf.Cos(angle);
        float x = Mathf.Sin(angle);

        v2 = new Vector2(x, y);

        transform.position = v2 * speed * Time.deltaTime + (Vector2)transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "x")
        {
            angle = -angle;
        }
        else
        {
            angle = -(angle - Mathf.PI);
        }
    }
}
