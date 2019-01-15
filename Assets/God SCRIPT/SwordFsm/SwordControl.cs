using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl:MonoBehaviour
{
    private SwordState _swordIdle    = new SwordIdle();
    private SwordState _swordInhand  = new SwordInHand();
    private SwordState _swordRotate  = new SwordRotate();
    private SwordState _swordThrow   = new SwordThrow();
    private SwordState _currentState = null;
    private void Start()
    {
        _currentState = _swordIdle;
    }
    private void Update()
    {
        _currentState.MyUpdate();
    }
    public void TranslateToState(SwordState target)
    {
        _currentState.PrepareExit();
        _currentState = target;
        _currentState.PrepareEnter();
    }
    public SwordState GetState(int num)
    {
        switch(num)
        {
            case 0:
                return _swordIdle;
            case 1:
                return _swordInhand;
            case 2:
                return _swordRotate;
            case 3:
                return _swordThrow;
            default:
                return _swordIdle;
        }
    }
}
