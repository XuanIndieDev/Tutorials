using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform startPoint;            //���ߵ����
    public Transform endPoint;              //���ߵ��յ�
    public Transform middlePoint;           //���ߵ��м��
    public float moveSpeed = 2.0f;          //�����ƶ��ٶ�

    private float curveLength;              //����·������
    private Vector3[] curvePoints;          //�����ϵĵ�

    private float startTime;                //��¼���忪ʼ�ƶ���ʱ��
    private int currentPointIndex = 0;      //��ǰ�������ڵĵ������

    void Start()
    {
        curveLength = CalculateCurveLength();   //��������·������
        curvePoints = new Vector3[100];          //���������ϵĵ������
        for (int i = 0; i < curvePoints.Length; i++)
        {
            float t = i / (float)(curvePoints.Length - 1);
            print(t);
            curvePoints[i] = CalculateBezierPoint(t);
        }
        startTime = Time.time;       //��¼��ǰʱ��
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * moveSpeed;  //�����Ѿ��ƶ��ľ���
        float fractionOfPath = distanceCovered / curveLength;         //�����������ϵ�λ��
        currentPointIndex = (int)Mathf.Floor(fractionOfPath * curvePoints.Length);     //��ǰ�������

       //���currentPointIndex�Ƿ񳬳�����ķ�Χ
        if (currentPointIndex < 0)
            currentPointIndex = 0;
        if (currentPointIndex >= curvePoints.Length)
            currentPointIndex = curvePoints.Length - 1;

        transform.position = Vector2.MoveTowards(transform.position, curvePoints[currentPointIndex], moveSpeed * Time.deltaTime);         //�ƶ�����ǰ��
    }


    //���㱴���������ϵĵ�
    private Vector3 CalculateBezierPoint(float t)
    {
        Vector3 p0 = startPoint.position;
        Vector3 p1 = middlePoint.position;
        Vector3 p2 = endPoint.position;
        float u = 1 - t;
        Vector3 p = u * u * p0 + 2 * u * t * p1 + t * t * p2;
        return p;
    }

    //��������·������
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
