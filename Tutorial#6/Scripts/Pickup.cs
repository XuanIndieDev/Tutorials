using System.Threading;
using TMPro;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] int fraction;
    [SerializeField] float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Gold")
            return;
        Destroy(collision.gameObject);
        fraction++;
        textMesh.text = textMesh.text + fraction;
    }

    private void Update()
    {
        Vector2 v2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.deltaTime;
        transform.position = v2 * speed + (Vector2)transform.position;
    }
}
