using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform target;
    public float Angle;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target").gameObject.transform;
    }

    private void Update()
    {
        moveDirection = target.transform.position - transform.position;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg, Vector3.forward);//此处为反方向如果想改成正方向把Atan2函数中的俩个参数改成正的就行了
        transform.rotation *= Quaternion.Euler(0f, 0f, Angle);
        Move();

        //Debug.DrawLine(transform.position, target.transform.position, Color.green,10);
    }
    public void Move() => transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
}
