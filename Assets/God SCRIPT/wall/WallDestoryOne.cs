using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterScript.Wall
{
    public class WallDestoryOne : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> monterList = new List<GameObject>();
        private bool destory = false;
        // Use this for initialization
        void Start()
        {
            int change = GameObject.Find("Flowchart-1").GetComponent<Flowchart>().GetIntegerVariable("Change")+1;
            GameObject.Find("Flowchart-1").GetComponent<Flowchart>().SetIntegerVariable("Change", change);
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            for(int i =0;i<monterList.Count;i++)
            {
                if (monterList[i] != null)
                {
                    return;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
