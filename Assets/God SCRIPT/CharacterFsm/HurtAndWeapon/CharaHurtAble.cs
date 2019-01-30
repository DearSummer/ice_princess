using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaHurtAble : MonoBehaviour
{
    public int maxHp;

    [SerializeField]
    private int currentHp;
    [SerializeField]
    private Animator ani;
    // Use this for initialization
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private bool die = false;
    public void GetHurt(HurtType ht, HurtData hd)
    {
        if (ht == HurtType.Damage)
        {
            currentHp = (currentHp - hd.damageFigure) > 0 ? currentHp - hd.damageFigure : 0;
            //根据伤害，来指定做一系列反应
            if (currentHp > 0)
            {
                ani.SetTrigger("TakeDamage");
                //fatherRig.AddForce(this.transform.forward * -5000,ForceMode.Acceleration);
            }
            else if (die == false)
            {
                die = true;
                //ani.SetBool("Die", true);
            }
        }
    }
}
