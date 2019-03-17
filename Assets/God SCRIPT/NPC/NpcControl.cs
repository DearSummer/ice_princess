using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
namespace NpcFungus
{
    public class NpcControl : MonoBehaviour
    {
        public string chatName;
        private bool canChat = false;
        [SerializeField]
        private Flowchart flowChart;
        // Use this for initialization
        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            canChat = true;
        }
        private void OnTriggerExit(Collider other)
        {
            canChat = false;
        }
        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.Y)&&other.name == "ForSearch")
            {
                Say();
            }
        }
        private void Say()
        {
            if(canChat == true)
            {
                if(flowChart.HasBlock(chatName))
                {
                    flowChart.ExecuteBlock(chatName);
                }
            }
        }
    }
}
