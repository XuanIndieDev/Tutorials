using UnityEngine;

public class Bimpact : MonoBehaviour
{
    [SerializeField] GameObject a, b;

    [SerializeField] bool i; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            i = !i;
            a.SetActive(i);
            b.SetActive(i);
        }
    }
}
