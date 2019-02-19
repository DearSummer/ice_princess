using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {
    public float interval = 0.1f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((interval-=(Time.deltaTime*2f))<0)
        {
            interval =0.1f;
            GameObject temp = BulletPool.Instance.GetBullet();
            temp.transform.position = this.transform.position;
            temp.GetComponent<BulletMove>().ResetInfo(this.transform.forward);
        }
	}
}
