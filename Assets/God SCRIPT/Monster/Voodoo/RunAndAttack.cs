using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Voodoo
{
    public class RunAndAttack : MonoBehaviour
    {
        private GameObject Target;
        [SerializeField]
        private GameObject My;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private bool SearchForDeath;
        [SerializeField]
        private AudioSource audiosource;
        [SerializeField]
        private GameObject disapper;
        private void Start()
        {
            Target = GameObject.Find("character");
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.name == "ForSearch")
            {
                animator.SetLayerWeight(animator.GetLayerIndex("New Layer"), 0.4f);
                animator.SetBool("Attack", true);
                SearchForDeath = true;
                StartCoroutine(Display());
                audiosource.Play();
            }
        }
        private void Update()
        {
            if(SearchForDeath)
            {

                Vector3 dir = -My.transform.position + new Vector3(Target.transform.position.x, My.transform.position.y, Target.transform.position.z);
                My.transform.LookAt(My.transform.position + dir);
                My.transform.position += My.transform.forward*Time.deltaTime*5f;
            }
        }
        IEnumerator  Display()
        {
            yield return new WaitForSeconds(10);
            GameObject.Instantiate(disapper, this.transform);
            yield return new WaitForSeconds(0.5f);
            Destroy(My);
        }
    }
}
