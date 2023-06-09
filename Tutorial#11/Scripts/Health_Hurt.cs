using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Health_Hurt : MonoBehaviour
{
    [SerializeField] Image image_Hurt;
    [SerializeField] Image image_Health;

    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] float currentHurt;
    [SerializeField] float maxHurt;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;

    [SerializeField] float speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SHealth(15);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AHealth(3);
        }
        image_Health.fillAmount = Mathf.Lerp(image_Health.fillAmount, currentHealth/maxHealth, speed * Time.deltaTime);
        image_Hurt.fillAmount = Mathf.Lerp(image_Hurt.fillAmount, currentHurt/maxHurt, speed * Time.deltaTime);
    }

    private void SHealth(float value)
    {
        currentHealth -= value;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        //image_Health.fillAmount = currentHealth / maxHealth;
        text.text = currentHealth.ToString();
        AHurt(value);
    }

    private void AHurt(float value)
    {
        currentHurt += value;
        currentHurt = Mathf.Clamp(currentHurt, 0, 100);
       // image_Hurt.fillAmount = currentHurt / maxHurt;
        text2.text = currentHurt.ToString();
        print(currentHurt.ToString());
    }

    private void AHealth(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        //image_Health.fillAmount = currentHealth / maxHealth;
        text.text = currentHealth.ToString();
        SHurt(value);
    }

    private void SHurt(float value)
    {
        currentHurt -= value;
        currentHurt = Mathf.Clamp(currentHurt, 0, 100);
        //image_Hurt.fillAmount = currentHurt / maxHurt;
        text2.text = currentHurt.ToString();
        print(currentHurt.ToString());
    }

}
