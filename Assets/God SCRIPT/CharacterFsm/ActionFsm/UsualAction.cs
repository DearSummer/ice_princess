using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimatorScript;
namespace ActionSpace
{
    public class UsualAction : BaseFsm
    {
        private int _doubleX = 2;//控制是否跑动
        private float _tempX = 1;//用来作为跑动lerp的插值
        private int _doubleY = 2;
        private float _tempY = 1;

        private Animator _ani;//人物控制器

        private GameObject player = null;

        private RandomAudioPlayer _audio;

        public override void MyUpdate(Animator _ani)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ControlFsm fsm = GameObject.FindWithTag("Player").GetComponent<ControlFsm>();
                fsm.Translate(fsm.GetFsmAssemble(1));
                PlayInfo.Instance._characterInfo = PlayInfo.characterInfo.attack;
            }
            LocalMotion(_ani);
            WalkOrRun(_ani);

        }

        public override void PrepareEnter(Animator _ani)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            _audio = _ani.GetComponent<RandomAudioPlayer>();
        }
        public override void PrepareExit(Animator _ani)
        {
            TransmitInfo(_ani);
            _tempX = 1;
            _doubleX = 2;
            _tempY = 1;
            _doubleY = 2;
        }
        private void LocalMotion(Animator _ani)//专门用来移动的
        {
            _tempX = Mathf.Lerp(_tempX, _doubleX, 0.05f);//计算插值
            _tempY = Mathf.Lerp(_tempY, _doubleY, 0.05f);
            _ani.SetFloat("forward", CharacterInput.Instance.m_MovementForward * _tempX);//设置为插值
            _ani.SetFloat("right"  , CharacterInput.Instance.m_MovementRight   * _tempY);
            PlayStepAudio(_ani);//播放是否发出脚步声
        }
        private void WalkOrRun(Animator ani)
        {
            //更具是否是跑的状态，调整到是否为跑，以便于攻击，闪避能快速的进入
            if (PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.Run)
            {
                _doubleX = 2;
            }
            else
            {
                _doubleX = 2;
            }
            if(PlayInfo.Instance._adjustVector.y==90|| PlayInfo.Instance._adjustVector.y==-90)
            {
                _doubleY = 2;
            }
            else
            {
                _doubleY = 2;
            }
        }

        //用于播放跑步声音
        private void PlayStepAudio(Animator _ani)
        {
            float footCurve = _ani.GetFloat("footCurve");

            if (footCurve > 0.01f && _audio.canPlay)
            {
                _audio.isPlaying = true;
                _audio.canPlay = false;
                _audio.RandomPlay();
            }
            else if (footCurve < 0.01f && !_audio.canPlay)
            {
                _audio.canPlay = true;
            }

            if (CharacterInput.Instance.m_MovementForward > 0.1f)
            {
                if (!_audio.isPlaying)
                {
                    _audio.isPlaying = true;
                }
                else
                {
                    _audio.isPlaying = false;
                }
            }
        }
        public override void MyFixUpdate(Animator _ani)
        {
            //要想办法解决，有时候trigger没有被触发
            //_ani.ResetTrigger("RunExit");
        }
        private void TransmitInfo(Animator _ani)
        {
            if(_ani.GetFloat("forward")>1.5f)
            {
                AnimatorInfo.Instance.Run = true;
            }
            else
            {
                AnimatorInfo.Instance.Run = false;
            }
        }
    }
}
