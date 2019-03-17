using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
    private Transform transformOfTargetObject;//目标物体
    private Vector3 offset;//摄像机对于角色的差量
    private Vector3 targetPosition;//计算后得到的摄像机位置
    private float speed = 5;//摄像机拉近速度
    private bool isCloser = false;//控制是否拉近
    private float dis;//用于记录当前距离，以判断是否达到不碰的临界
    void Start()
    {
        //初始化
        transformOfTargetObject = GameObject.Find("character").GetComponent<Transform>();
        offset = gameObject.transform.position - transformOfTargetObject.position;
        dis = Vector3.Distance(gameObject.transform.position, transformOfTargetObject.position);
    }

    void Update()
    {
        //获得由物体射向摄像机的射线以及碰到的所有物体hits
        Vector3 dir = -(transformOfTargetObject.position - transform.position).normalized;
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transformOfTargetObject.position, dir, Vector3.Distance(transformOfTargetObject.position, transform.position));
        //有碰到且物体没有移走，就拉近
        if (hits.Length > 0 && dis > Vector3.Distance(gameObject.transform.position, transformOfTargetObject.position))
        {
            isCloser = true;
        }
        else
        {
            isCloser = false;
        }
        if (isCloser)
        {
            //拉近
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, hits[0].point, Time.deltaTime * speed); ;
            gameObject.transform.LookAt(transformOfTargetObject);
            isCloser = false;
        }
        else
        {
            //正常跟随
            targetPosition = transformOfTargetObject.position + transformOfTargetObject.TransformDirection(offset);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, Time.deltaTime * speed);
            gameObject.transform.LookAt(transformOfTargetObject);
        }

    }
}
