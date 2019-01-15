using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwordState {

    public abstract void MyUpdate();
    public abstract void PrepareEnter();
    public abstract void PrepareExit();
}
