using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConrol : MonoBehaviour {
    private  float _posX;
    private  float _posY;
    public float _sentivity = 0.1f;
    public int _r = 5;
    public GameObject _center;
	// Use this for initialization
	void Start () {
        _posX = this.transform.localEulerAngles.x;
        _posY = this.transform.localEulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
    private float angle = 0;
    private Vector3 velocity = Vector3.zero  ;
	// Update is called once per frame
	void Update () {
        ///camer
        CamerRotate();
        ///
        
    }
    public void CamerRotate()
    {
        _posX = Input.GetAxis("Mouse X") * Time.deltaTime * _sentivity;
        _posY = Input.GetAxis("Mouse Y") * Time.deltaTime * _sentivity;
        // translate
        angle += _posX / (2 * 3.14f * _r) * 360;
        if (angle < 0) angle = 360 - angle;
        angle = angle % 360;
        Vector3 target = _center.transform.position + new Vector3(_r * Mathf.Sin(angle), 3, _r * Mathf.Cos(angle));
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.3f);
        this.transform.LookAt(_center.transform.position);
    }
}
