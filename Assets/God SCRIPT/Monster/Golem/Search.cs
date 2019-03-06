using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Golem
{
    public class Search : MonoBehaviour
    {
        [SerializeField]
        private GolemEvent golemEvent;
        [SerializeField]
        private GameObject Target;
        [SerializeField]
        private GameObject My;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "ForSearch")
            {
                golemEvent.TranslateToRun();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.name == "ForSearch")
            {
                My.transform.LookAt(new Vector3(Target.transform.position.x, My.transform.position.y, Target.transform.position.z));
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "ForSearch")
            {
                golemEvent.TranslateToIdle();
            }
        }
        private void LateUpdate()
        {
            if(golemEvent.run) My.transform.position += My.transform.forward * Time.deltaTime * 3f; 
        }
    }
}
