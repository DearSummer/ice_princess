using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MonsterScript.Fsm
{
    public interface BaseMonterFsm
    {
        void PrepareEnter(Animator ani, AudioSource ads);
        void PrepareExit();
        void MyUpdate();
    }
}

