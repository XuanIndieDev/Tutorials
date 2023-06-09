using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float currentHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SubtractHealth();
    }

    private void SubtractHealth()
    {
        currentHealth -= 5;
    }
}
