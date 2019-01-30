
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


    private Vector3 animMove = Vector3.zero;
    public Vector3 GetDoitMove
    {
        get
        {
            return deltMove;
        }
    }

    /////////////
    private bool CanTranslate = true;
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
    public BaseFsm GetFsm
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
    }
	
	// Update is called once per frame
	void Update () {
        _currentFsm.MyUpdate(_ani);
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.injured;
            Translate(_beAttackedFsm);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.jump;
            Translate(_jumpFsm);
        }
        ///以下为实验阶段，可能架构很烂
        if (PlayInfo.Instance._characterInfo == PlayInfo.characterInfo.action && _currentFsm != _actionFsm)
        {
            Translate(_actionFsm);
            this.GetComponentInChildren<AnimEvent>().SwordIdle();
            _ani.SetTrigger("IsExitNow");
            _ani.SetTrigger("Run");
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
        //this.transform.RotateAround(this.transform.position, this.transform.up, CharacterInput.Instance.CamerVector.x * 10);
        if (_transY == true|| PlayInfo.Instance._actionInfo != PlayInfo.actionInfo.BackRun)
        {
            
            Quaternion c = _followCamera.transform.rotation;
            c.Set(this.transform.rotation.x, c.y, this.transform.rotation.z, c.w);
            Quaternion q = Quaternion.Slerp(this.transform.rotation, c, 0.1f);
            this.transform.rotation = q;
        }
        if (PlayInfo.Instance._isFirstInit ==true)
        {
            PlayInfo.Instance._isFirstInit = false;
            _transY = false;
            this.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            StartCoroutine(WaitToEnableTransY());
        }
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
    private bool _transY = true;
    IEnumerator WaitToEnableTransY()
    {
        yield return new WaitForSeconds(5);
        _transY = true;
    }
}
