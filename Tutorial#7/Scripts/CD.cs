using UnityEngine;
using UnityEngine.UI;

public class CD : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] bool isCD;
    [SerializeField] float currentCD;
    [SerializeField] float maxCD;

    private void Awake()
    {
        currentCD = maxCD;
    }

    private void Update()
    {
        if (isCD)
        {
            currentCD -= 1 * Time.deltaTime;
            currentCD = Mathf.Clamp(currentCD, 0, maxCD);
            image.fillAmount = currentCD / maxCD;
            print(currentCD / maxCD);
        }
    }
}
