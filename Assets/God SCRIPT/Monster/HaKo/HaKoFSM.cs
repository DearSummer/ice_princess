using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaKoFSM : MonoBehaviour {
    private Animator _ani;
    private BaseFsm _HaKoIdle = new HaKoIdle();
    private BaseFsm _HaKoBeAttacked = new HaKoBeattacked();

    private BaseFsm _currentFsm;
	// Use this for initialization
	void Start () {
        _ani = GetComponent<Animator>();
        _currentFsm = _HaKoIdle;
        _currentFsm.PrepareEnter(_ani);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public BaseFsm GetStateList(int num)
    {
        switch(num)
        {
            case 0:
                return _HaKoIdle;
            case 1:
                return _HaKoBeAttacked;
            default:
                return null;
        }
    }
    public void Translate(BaseFsm targetFsm)
    {
        _currentFsm.PrepareExit(_ani);
        _currentFsm = targetFsm;
        _currentFsm.PrepareEnter(_ani);
    }
}
