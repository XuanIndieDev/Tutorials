using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatText : MonoBehaviour
{
    [SerializeField] GameObject preFab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Hit(Random.Range(5,15));
        }
    }

    public void Hit(float hurt)
    {
        GameObject obj = Instantiate(preFab, transform.position,Quaternion.identity);
        //obj.transform.parent = transform;
        preFab.GetComponent<Canvas>().worldCamera = Camera.main;
        obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = hurt.ToString();
        Destroy(obj,1f);
    }
}
