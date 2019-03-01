using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterScript.Fsm;
public class HurtAble : MonoBehaviour
{
    private List<IMsgReceiver<HurtType, HurtData>> receiverList = new List<IMsgReceiver<HurtType, HurtData>>();
    public int maxHp;
    [SerializeField]
    private int currentHp;

    [SerializeField]
    private Animator ani;

    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private FinalMachine finialMachine;
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
            if(currentHp>0)
            {
                finialMachine.TranslateToDamge();
                //fatherRig.AddForce(this.transform.forward * -5000,ForceMode.Acceleration);
                
            }
            else if(currentHp<0||currentHp==0)
            {
                ani.SetBool("Die", true);
                StartCoroutine(Destory());
            }
        }
    }
    IEnumerator Destory()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Instantiate(ps, this.transform);
        //ef.RunEffect();
        yield return new WaitForSeconds(0.5f);
        Explosion();
        Destroy(this.transform.parent.gameObject);
    }
    private void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 8);
        for(int i = 0;i<colliders.Length-1;i++)
        {
            if(colliders[i].gameObject.layer==9|| (colliders[i].gameObject.layer==10&&colliders[i].gameObject.tag == "Monster"))
            {
                float ForceN = 5000/(colliders[i].gameObject.transform.position - this.transform.position).magnitude;
                Vector3 dir = (colliders[i].gameObject.transform.position - this.transform.position).normalized;
                colliders[i].gameObject.GetComponent<Rigidbody>().AddForce(dir * ForceN);
            }
        }
    }
}
