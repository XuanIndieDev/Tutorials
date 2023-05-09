using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] Vector2 a;
    [SerializeField] Vector2 b;
    [SerializeField] Transform a_Trans;
    [SerializeField] Transform b_Trans;
    [SerializeField] bool isAB;
    [SerializeField] float speed;

    private void Awake()
    {
        a_Trans.position = a;
        b_Trans.position = b;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isAB)
        {
            transform.position = Vector2.MoveTowards(transform.position, b, speed * Time.realtimeSinceStartup*0.01f);
            if ((Vector2)transform.position == b)
            {
                isAB = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, a, speed * Time.realtimeSinceStartup*0.01f);
            if ((Vector2)transform.position == a)
            {
                isAB = true;
            }
        }
    }
}
