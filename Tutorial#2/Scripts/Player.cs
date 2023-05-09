using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] Image health_2;
    [SerializeField] Image health_3;
    [SerializeField] float speed;

    private void Awake()
    {
        currentHealth = maxHealth;
        health_2.fillAmount = currentHealth;
        health_3.fillAmount = currentHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Subtract();
        }
        health_2.fillAmount = Mathf.Lerp(health_2.fillAmount, health_3.fillAmount, speed * Time.deltaTime);
    }

    private void Subtract()
    {
        currentHealth -= 15f;
        health_3.fillAmount = currentHealth/maxHealth;
        currentHealth = Mathf.Clamp(currentHealth,0, maxHealth);    

    }
}
