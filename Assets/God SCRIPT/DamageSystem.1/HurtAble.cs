using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtAble : MonoBehaviour {
    private List<IMsgReceiver<HurtType, HurtData>> receiverList = new List<IMsgReceiver<HurtType, HurtData>>();
    public int maxHp;
    [SerializeField]
    private int currentHp;

    [SerializeField]
    private Animator ani;
	// Use this for initialization
	void Start () {
        currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Register(IMsgReceiver<HurtType, HurtData> receiver)
    {
        if (!receiverList.Contains(receiver))
            receiverList.Add(receiver);
    }
    private void Remove(IMsgReceiver<HurtType,HurtData> receiver)
    {
        if(receiverList.Contains(receiver))
        {
            receiverList.Remove(receiver);
        }
    }
    public  void GetHurt(HurtType ht,HurtData hd)
    {
        if(ht == HurtType.Damage)
        {
            currentHp = (currentHp - hd.damageFigure) > 0 ? currentHp - hd.damageFigure : 0;

            //根据伤害，来指定做一系列反应
            if(currentHp>0) ani.SetTrigger("TakeDamage");
            else
            {
                ani.SetBool("Die", true);
                StartCoroutine(Destory());
            }
        }
    }
    IEnumerator Destory()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.transform.parent.gameObject);
    }

}
