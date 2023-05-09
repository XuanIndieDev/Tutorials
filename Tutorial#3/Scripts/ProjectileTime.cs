using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTime : MonoBehaviour
{
    [SerializeField][Range(0, 1)] float time;
    private void Update()
    {
        Time.timeScale = time;
    }
}
