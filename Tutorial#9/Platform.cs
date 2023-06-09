using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] Collider2D boxCollider2D;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (boxCollider2D == null) return;
            boxCollider2D.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (boxCollider2D == null) return;
            boxCollider2D.enabled = true;
            boxCollider2D = null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Platform") return;
        boxCollider2D = collision.gameObject.GetComponent<Collider2D>();
    }
}
