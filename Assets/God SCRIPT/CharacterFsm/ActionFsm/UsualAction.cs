using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionSpace
{
    public class UsualAction : BaseFsm
    {
        private int _double = 1;//控制是否跑动
        private float _temp = 1;//用来作为跑动lerp的插值
        private Animator _ani;//人物控制器

        private GameObject player = null;

        private RandomAudioPlayer _audio;

        public override void MyUpdate(Animator _ani)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ControlFsm fsm = GameObject.FindWithTag("Player").GetComponent<ControlFsm>();
                if (_ani.GetFloat("forward") >= 1.5f)
                {
                    _ani.SetBool("IsRunAttack", true);
                }
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

            //_ani.ResetTrigger("IsExitNow");//所有强制触发的都要重置一遍
           // _ani.ResetTrigger("RunExit");
        }
        public override void PrepareExit(Animator _ani)
        {
            _temp = 1;
            _double = 1;
        }
        private void LocalMotion(Animator _ani)//专门用来移动的
        {
            _temp = Mathf.Lerp(_temp, _double, 0.05f);//计算插值
            _ani.SetFloat("forward", CharacterInput.Instance.m_MovementForward * _temp);//设置为插值
            _ani.SetFloat("right", CharacterInput.Instance.m_MovementRight);
            PlayStepAudio(_ani);//播放是否发出脚步声
        }
        private void WalkOrRun(Animator ani)
        {
            //更具是否是跑的状态，调整到是否为跑，以便于攻击，闪避能快速的进入
            if (PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.Run || PlayInfo.Instance._actionInfo == PlayInfo.actionInfo.BackRun)
            {
                _double = 2;
            }
            else
            {
                _double = 1;
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
    }
}
