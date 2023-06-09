using System.Collections;
using UnityEngine;

public class TimeBack : MonoBehaviour
{
    public Stack datas = new Stack();
    
    public Data data = new Data();

    private void SaveData()
    {
        Data data = new Data();
        data.position = transform.position;
        print(data.position);
        datas.Push(data);
    }

    private Data LoadData() 
    {
        if (datas.Count > 1)
        {
            return (Data)datas.Pop();
        }
        else
        {
            return (Data)datas.Peek();
        }
    }

    void ShowData(Data data)
    {   
        transform.position = data.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            data = LoadData();
            if (data != null)
            {
                ShowData(data);
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
        else
        {
            SaveData();
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
