using UnityEngine;
using System.Collections;

public class Transmission : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool isTransmission;
    [SerializeField] float time;

    private void Update()
    {
        if (!isTransmission)
        {
            if (time < 0.5f)
            {
                time += Time.deltaTime;
                time = Mathf.Clamp(time, 0f, 0.5f);
            }
            else
            {
                time = 0f;
                isTransmission = true;
            }
        }
    }

    private void Start()
    {
       isTransmission = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTransmission) return;
        if (collision.gameObject.tag != "Player") return;
        collision.transform.position = target.transform.position;
        target.GetComponent<Transmission>().isTransmission = false;
    }
}
