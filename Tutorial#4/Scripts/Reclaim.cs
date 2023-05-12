using UnityEngine;

public class Reclaim : MonoBehaviour
{
    [SerializeField] Pool pool;
    [SerializeField] Vector2 v2;
    [SerializeField] float speed;

    private void Awake()
    {
        v2 = new Vector2(-15,-15);
        speed = Random.Range(3, 7);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,v2, speed*Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        pool.pool.Release(gameObject);

    }
}
