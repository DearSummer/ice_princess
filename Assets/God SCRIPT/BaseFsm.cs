using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseFsm {
    public abstract void MyUpdate(Animator _ani);
    public abstract void MyFixUpdate(Animator _ani);
    public abstract void PrepareEnter(Animator _ani);
    public abstract void PrepareExit(Animator _ani);
}
