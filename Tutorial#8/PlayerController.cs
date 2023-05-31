using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 input;

    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        transform.position = input * speed * Time.deltaTime + (Vector2)transform.position;
    }
}
