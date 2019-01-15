using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    private Animator _ani;
    private AnimatorStateInfo _As;
    public GameObject target;
    // Use this for initialization
    void Start () {
        _ani=GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        ToCamera();
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _ani.SetInteger("state", 3);
                return;
            }
            _ani.SetInteger("state", 1);
            return;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            _ani.SetInteger("state", 0);
        }
	}
    private void ToCamera()
    {
        Vector3 temptaget = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(temptaget - transform.position), 5 * Time.deltaTime);
    }
}
