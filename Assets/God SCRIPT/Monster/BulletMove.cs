using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    private Vector3 dir;
	// Use this for initialization
	void Start () {
		
	}
	public void ResetInfo(Vector3 direction)
    {
        dir = direction;
        StartCoroutine(DestroySelf());
    }
	// Update is called once per frame
	void Update () {
        this.transform.position += dir * Time.deltaTime*2;
	}
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5);
        BulletPool.Instance.ReturnBullet(this.gameObject);
    }
}
