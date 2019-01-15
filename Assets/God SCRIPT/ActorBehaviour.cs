using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBehaviour : MonoBehaviour, IMessageReceiver<DamageType, DamageData>
{
    public MeleeWeapon weapon;
    public Damageable damageable;

    [SerializeField]
    private HaKoFSM Fsm;
    [SerializeField]
   // private RandomAudioPlayer audio;
    private void Awake()
    {
        if (weapon != null)
            weapon.SetMaster(this.gameObject);
        damageable.Register(this);
    }


    public void ReceiverMessage(DamageType type, object sender, DamageData data)
    {
        if(Fsm) Fsm.Translate(Fsm.GetStateList(1));
    }

}
