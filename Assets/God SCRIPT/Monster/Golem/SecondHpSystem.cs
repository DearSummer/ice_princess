using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Golem
{
    public class SecondHpSystem : MonoBehaviour
    {
        public int maxHp;
        [SerializeField]
        private int currentHp;
        [SerializeField]
        private ParticleSystem blood;
        [SerializeField]
        private ParticleSystem ps;
        [SerializeField]
        private GolemEvent golemEvent;

        private int HitChoice = 0;
        private void Start()
        {
            currentHp = maxHp;
        }
        public void GetHurt(HurtType ht, HurtData hd)
        {
            if (ht == HurtType.Damage)
            {
                currentHp = (currentHp - hd.damageFigure) > 0 ? currentHp - hd.damageFigure : 0;
                //根据伤害，来指定做一系列反应
                if (currentHp > 0)
                {
                    HitChoice++;
                    HitChoice = HitChoice > 2 ? 0 : HitChoice;
                    golemEvent.TranslateToHit(HitChoice);
                    GameObject.Instantiate(blood, this.transform).Play();
                    //fatherRig.AddForce(this.transform.forward * -5000,ForceMode.Acceleration);

                }
                else if (currentHp < 0 || currentHp == 0)
                {
                    StartCoroutine(Destory());
                }
            }
        }
        IEnumerator Destory()
        {
            GameObject.Instantiate(ps, this.transform);
            yield return new WaitForSeconds(0.5f);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
