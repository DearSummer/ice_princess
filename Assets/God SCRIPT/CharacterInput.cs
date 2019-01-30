using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour {
    [SerializeField]
    private string _keyOfForward;
    [SerializeField]
    private string _keyOfBack;
    [SerializeField]
    private string _keyOfRight;
    [SerializeField]
    private string _keyOfLeft;

    [SerializeField]
    private Vector2 m_Movement = Vector2.zero;
    [SerializeField]
    private Vector2 m_Camera   = Vector2.zero;

    public float m_MovementForward = 0;
    public float m_MovementRight = 0;

    private float m_CameraForward = 0;
    private float m_CameraRight = 0;
    private bool _enable = true;

    private float m_timeLost = 0.0f;
    public bool InputEnable
    {
        set
        {
            _enable = value;
            m_MovementForward = 0;
            m_MovementRight = 0;
            m_Movement.x = 0;
            m_Movement.y = 0;
        }
        get
        {
            return _enable;
        }
    }

    public Vector2 InputVector
    {
        get
        {
            return m_Movement;
        }
    }
    public Vector2 CamerVector
    {
        get
        {
            return m_Camera;
        }
    }
    
    private static CharacterInput instance;
    public static CharacterInput Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(_enable)
        {
            GetKeyBoard();
        }
        GetMouse();
        WalkOrRun();
    }
    private void GetKeyBoard()
    {
        m_MovementRight = Input.GetAxis("Horizontal");
        m_MovementForward = Input.GetAxis("Vertical");
        //translate to circle coordinates
        m_Movement.x = m_MovementRight * Mathf.Sqrt(1 - (m_MovementForward * m_MovementForward) / 2.0f);
        m_Movement.y = m_MovementForward * Mathf.Sqrt(1 - (m_MovementRight * m_MovementRight) / 2.0f);
    }
    private void GetMouse()
    {
        m_CameraForward = float.IsNaN(Input.GetAxis("Mouse Y")) ?0: Input.GetAxis("Mouse Y");
        m_CameraRight = float.IsNaN(Input.GetAxis("Mouse X")) ? 0:Input.GetAxis("Mouse X");
        //translate to circle coordinates
        m_Camera.x = m_CameraRight * Mathf.Sqrt(1 - (m_CameraForward * m_CameraForward) / 2.0f);
        m_Camera.x = float.IsNaN(m_Camera.x) ? 0:m_Camera.x;
        m_Camera.y = m_CameraForward * Mathf.Sqrt(1 - (m_CameraRight * m_CameraRight) / 2.0f);
        m_Camera.y = float.IsNaN(m_Camera.y) ? 0 : m_Camera.y;
    }
    //用于攻击的时候是否进入跑的状态，由于为了更强的效果，所以进入跑这个应该是所有状态都能够进入，思来想去，放在这个里面最为合适
    private void WalkOrRun()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time - m_timeLost <= 0.2f)
            {
                PlayInfo.Instance._actionInfo = PlayInfo.actionInfo.SprintRun;
                PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.action;
            }
            m_timeLost = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            PlayInfo.instance._actionInfo = PlayInfo.actionInfo.walk;
            //GameObject.Find("FootstepAudio").GetComponent<AudioSource>().Stop();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Time.time - m_timeLost <= 0.2f)
            {
                PlayInfo.instance._actionInfo = PlayInfo.actionInfo.BackRun;
                PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.action;
                PlayInfo.instance._isFirstInit = true;
            }
            m_timeLost = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            PlayInfo.instance._isFirstInit = false;
        }
    }
}
