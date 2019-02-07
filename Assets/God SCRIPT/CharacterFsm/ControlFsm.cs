
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFsm : MonoBehaviour {

    private Animator _ani;
    private BaseFsm _actionFsm = new ActionFsm();
    private BaseFsm _attackFsm = new AttackFsm();
    private BaseFsm _beAttackedFsm = new BeAttackedFsm();
    private BaseFsm _jumpFsm = new JumpFsm();
    private BaseFsm _currentFsm;

    private CharacterInput _input;

    private Vector3 animMove = Vector3.zero;
    public Vector3 GetDoitMove
    {
        get
        {
            return deltMove;
        }
    }

    /////////////
    public BaseFsm GetFsmAssemble(int num)
    {
        switch(num)
        {
            case 0:
                return _actionFsm;
            case 1:
                return _attackFsm;
            case 2:
                return _beAttackedFsm;
            case 3:
                return _jumpFsm;
            default:
                return null;
        }
    }
    private BaseFsm GetFsm
    {
        get { return _currentFsm; }
    }
	// Use this for initialization
	void Start () {
        _ani = this.GetComponentInChildren<Animator>();
        _currentFsm = _actionFsm;
        _currentFsm.PrepareEnter(_ani);
        _followCamera = GameObject.FindWithTag("FollowCamera");

        lastPosition = this.transform.position;

        _input = this.GetComponent<CharacterInput>();
    }
	
	// Update is called once per frame
	void Update () {
        _currentFsm.MyUpdate(_ani);
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.injured;
            Translate(_beAttackedFsm);
        }
        ///以下为实验阶段，可能架构很烂
        if (PlayInfo.Instance._characterInfo == PlayInfo.characterInfo.action && _currentFsm != _actionFsm)
        {
            Translate(_actionFsm);
            this.GetComponentInChildren<AnimEvent>().SwordIdle();
            _ani.SetTrigger("IsExitNow");
            //_ani.SetTrigger("Run");
        }
    }

    public void Translate(BaseFsm nextFsm)
    {
        _currentFsm.PrepareExit(_ani);
        _currentFsm = nextFsm;
        _currentFsm.PrepareEnter(_ani);
    }

    /// <summary>
    /// 写在这是不合理的，暂时看实现效果要向摄像机方向跑
    /// </summary>
    private GameObject _followCamera;
    private void FixedUpdate()
    {
        _currentFsm.MyFixUpdate(_ani);
        FollowWithCamera();
        this.transform.position += (animMove);
        deltMove = this.transform.position - lastPosition;
        lastPosition = this.transform.position;
        animMove = Vector3.zero;
    }
    private Vector3 deltMove = Vector3.zero;
    private Vector3 lastPosition = Vector3.zero;
    public void AnimationMove(Vector3 vec)
    {
        animMove += vec;
    }

    private void FollowWithCamera()
    {
        if(_input.m_MovementForward!=0||_input.m_MovementRight!=0)
        {
            int dirX = _input.m_MovementForward > 0 ? 0 : -1;
            //int dirY = _input.m_MovementRight > 0 ? 1 : -1;
            Vector3 todir = Vector3.zero;
            if(_input.m_MovementForward!=0)
            {
                todir = new Vector3(this.transform.rotation.x, _followCamera.transform.rotation.eulerAngles.y+180*dirX, this.transform.rotation.z);
            }
            else
            {
                todir = new Vector3(this.transform.rotation.x, _followCamera.transform.rotation.eulerAngles.y, this.transform.rotation.z);
            }
            Quaternion todirQuateranion = Quaternion.Euler(todir);
            Quaternion c = Quaternion.Slerp(this.transform.rotation, todirQuateranion, 0.1f);
            this.transform.rotation = c;
        }
    }
}
