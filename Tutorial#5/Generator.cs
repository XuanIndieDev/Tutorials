using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject preFab;
    [SerializeField] float time;
    [SerializeField] float maxTime;
    private void Update()
    {
        if (preFab == null)
            return;
        if (time == maxTime)
        {
            time = 0;
            Instantiate(preFab, transform.position, Quaternion.identity);
            preFab.GetComponent<Projectile>().Angle = Random.Range(-45, 45);
        }
        else
        {
            time += Time.deltaTime; 
            time = Mathf.Clamp(time, 0, maxTime);
        }
    }
}
