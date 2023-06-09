using UnityEngine;

public class Stab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CannotSelected>().Hit();
    }
}
