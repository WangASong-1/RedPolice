using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGroupMath : MonoBehaviour
{

    //质量
    public float m = 1f;
    //加速度
    public Vector3 velocity = Vector3.zero;

    //函数调用间隔
    public float time = 0.2f;

    //运动速度
    public float speed = .1f;
    //目标点
    public Transform target;
    //前进方向
    public Vector3 sumDir = Vector3.zero;

    //分离范围
    public float separationScop = 1.5f;
    //分离方向
    public Vector3 separationDir = Vector3.zero;
    //分离范围内的所有成员
    public Collider[] separationNeghbar;
    //分离比重
    public float separetionWeigth = 1f;

    //聚合范围
    public float cohisionScop = 6f;
    //聚合方向
    public Vector3 cohisionDir = Vector3.zero;
    //聚合范围内的所有成员
    public Collider[] cohisionNeghbar;
    //聚合比重
    public float cohisionWeigth = 1f;

    //队列范围
    public float alignmentScop = 3f;
    //队列范围内的成员
    public Collider[] alignmentNeghbar;
    //队列方向
    public Vector3 alignmentDir = Vector3.zero;
    //队列比重
    public float alignmentWeigth = 1f;
    //队列成员方向和
    public Vector3 alignmentsDir = Vector3.zero;

    private void Start()
    {
        target = GameObject.Find("Target").transform;
        InvokeRepeating("GetSumDir", 0, time);
    }


    /// <summary>
    /// 得到一个总的方向
    /// </summary>
    public void GetSumDir()
    {
        //进入清空方向
        separationDir = Vector3.zero;
        cohisionDir = Vector3.zero;
        alignmentDir = Vector3.zero;
        sumDir = Vector3.zero;
        alignmentsDir = Vector3.zero;




        //分离方向 
        separationNeghbar = Physics.OverlapSphere(transform.position, separationScop);
        if (separationNeghbar.Length > 1)
        {
            foreach (Collider n in separationNeghbar)
            {
                if (n.gameObject != gameObject)
                {
                    separationDir += (transform.position - n.transform.position).normalized;
                }
            }
            sumDir += (separationDir * separetionWeigth);
        }


        //聚合方向
        if (separationNeghbar.Length <= 1)
        {
            Vector3 center = Vector3.zero;
            cohisionNeghbar = Physics.OverlapSphere(transform.position, cohisionScop);
            if (cohisionNeghbar.Length > 1)
            {
                foreach (Collider n in cohisionNeghbar)
                {
                    center += n.transform.position;
                }
                center /= cohisionNeghbar.Length;
            }
            cohisionDir += (center - transform.position);
            sumDir += (cohisionDir *= cohisionWeigth);
        }

        //队列方向
        alignmentNeghbar = Physics.OverlapSphere(transform.position, alignmentScop);
        if (alignmentNeghbar.Length > 1)
        {
            foreach (Collider n in alignmentNeghbar)
            {
                if (n.gameObject != gameObject)
                {
                    alignmentsDir += n.transform.forward;
                }
            }
            alignmentsDir /= (alignmentNeghbar.Length - 1);
            alignmentDir = (alignmentsDir - transform.forward);
            sumDir += (alignmentDir * alignmentWeigth);
        }

        //目标点方向
        sumDir += ((target.position - transform.position).normalized - transform.forward) * speed;
    }


    private void FixedUpdate()
    {
        //公式F = ma;  所以 a = F/m
        Vector3 a = sumDir / m;
        a.y = 0;
        velocity += a * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(velocity);
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }
}
