using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllar : MonoBehaviour
{
    //鼠标点击位置的向量
    Vector3 targeTharform;
    //这条射线是在鼠标位置，从屏幕射出一条射向世界空间的射线
    Ray ray;
    //射线投射用于检测沿射线路径的对象，就像在场景发射的激光束，观察哪些对象被它击中
    RaycastHit rayHit;
    //记录鼠标点击的位置向量
    List<Vector3> record = new List<Vector3>();
    public float speed;
    
    Camera cam;

    void Start()
    {
        //获取相机组件
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        OnClick();
        Turn();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        Moves(record);
        
    }

    /*private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
       character.Move(v);
       character.Roate(h);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            character.Fire();
       }
    }*/

    void OnClick()
    {
        //这条射线是在鼠标位置，从屏幕射出一条射向世界空间的射线
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            //输出一条射线
            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider.name == "GroundPlane")
                {
                    //记录鼠标点击位置的向量
                    record.Add(rayHit.point);
                    //使点击位置向量的y轴与player向量的y轴相同。这样能保证移动的时候不会上下飘动
                    targeTharform.y = transform.position.y;
                }
            }
        }
    }

    void Moves(List<Vector3> a)
    {
        if (record.Count > 0)
        {
            //当前位置的向量到目标位置向量的距离，等于两个向量之间的差
            targeTharform = a[0] - transform.position;
            //玩家移动为得出的两个向量差的向量的标量来计算
            transform.position += targeTharform.normalized * speed * Time.deltaTime;
            //若当前位置与目标向量的距离小于一定距离，就停止移动
            if ((Vector3.Distance(a[0], transform.position) < 1f))
            {
                Debug.Log(111);
                record.RemoveAt(0);
            }
        }
    }

    void Turn()
    {
        //欧拉角
        Quaternion q = new Quaternion();
        //建立一个旋转，沿着Z轴，并且头部沿着y轴。
        q.SetLookRotation(targeTharform);
        //物体的旋转角度就等与求出四元数的旋转角度
        transform.rotation = q;
    }

    
}
