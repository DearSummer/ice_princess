using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {


    private List<IMessageReceiver<DamageType, DamageData>> recceiverList = new List<IMessageReceiver<DamageType, DamageData>>();

    public int maxHp;

    public UnityEvent OnRecover, OnGetHurt;

    [SerializeField]
    private int currentHp;

    private void Start()
    {
        Recover(maxHp);
    }

    public void Register(IMessageReceiver<DamageType,DamageData> receiver)
    {
        if (!recceiverList.Contains(receiver))
            recceiverList.Add(receiver);
    }

    public void Remove(IMessageReceiver<DamageType, DamageData> r)
    {
        recceiverList.Remove(r);
    }

    public void TryGetHurt(DamageData data)
    {
        if (currentHp < 0)
            return;

        currentHp -= data.damage;
        DamageType type = DamageType.damage;

        OnGetHurt.Invoke();

        for (int i = 0; i < recceiverList.Count; ++i)
        {
            recceiverList[i].ReceiverMessage(type, this, data);
        }
    }

    public void Recover(int hp)
    {
        currentHp += hp;

        OnRecover.Invoke();
    }
}
