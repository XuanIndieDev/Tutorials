using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform startPoint;            //曲线的起点
    public Transform endPoint;              //曲线的终点
    public Transform middlePoint;           //曲线的中间点
    public float moveSpeed = 2.0f;          //物体移动速度

    private float curveLength;              //曲线路径长度
    private Vector3[] curvePoints;          //曲线上的点

    private float startTime;                //记录物体开始移动的时间
    private int currentPointIndex = 0;      //当前物体所在的点的索引

    void Start()
    {
        curveLength = CalculateCurveLength();   //计算曲线路径长度
        curvePoints = new Vector3[100];          //创建曲线上的点的数组
        for (int i = 0; i < curvePoints.Length; i++)
        {
            float t = i / (float)(curvePoints.Length - 1);
            print(t);
            curvePoints[i] = CalculateBezierPoint(t);
        }
        startTime = Time.time;       //记录当前时间
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * moveSpeed;  //物体已经移动的距离
        float fractionOfPath = distanceCovered / curveLength;         //物体在曲线上的位置
        currentPointIndex = (int)Mathf.Floor(fractionOfPath * curvePoints.Length);     //当前点的索引

       //检查currentPointIndex是否超出数组的范围
        if (currentPointIndex < 0)
            currentPointIndex = 0;
        if (currentPointIndex >= curvePoints.Length)
            currentPointIndex = curvePoints.Length - 1;

        transform.position = Vector2.MoveTowards(transform.position, curvePoints[currentPointIndex], moveSpeed * Time.deltaTime);         //移动到当前点
    }


    //计算贝塞尔曲线上的点
    private Vector3 CalculateBezierPoint(float t)
    {
        Vector3 p0 = startPoint.position;
        Vector3 p1 = middlePoint.position;
        Vector3 p2 = endPoint.position;
        float u = 1 - t;
        Vector3 p = u * u * p0 + 2 * u * t * p1 + t * t * p2;
        return p;
    }

    //计算曲线路径长度
    private float CalculateCurveLength()
    {
        float curveLength = 0;
        Vector3 lastPoint = CalculateBezierPoint(0);
        for (float i = 0.01f; i < 1; i += 0.01f)
        {
            Vector3 thisPoint = CalculateBezierPoint(i);
            curveLength += Vector3.Distance(thisPoint, lastPoint);
            lastPoint = thisPoint;
        }
        return curveLength;
    }
}
