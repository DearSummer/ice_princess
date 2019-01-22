using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterSearch : MonoBehaviour {
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private GameObject tra;
    private NavMeshAgent nav;

    private bool isSearch = false;
    [SerializeField]
    private GameObject searchObj;
    // Use this for initialization
    void Start () {
        nav = tra.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==9&&other.tag=="Player"&&other.name== "character")
        {
            Debug.Log("ing");
            ani.SetBool("Move", true);
            isSearch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 && other.gameObject.tag == "Player")
        {
            Debug.Log("out");
            isSearch = false;
            ani.SetBool("Move", false);
            ani.SetBool("Attack 01", false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 && other.gameObject.tag == "Player")
        {
            nav.SetDestination(searchObj.transform.position);
        }
    }
}
