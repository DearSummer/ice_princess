using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: Billy
//  description:  
//-------------------------------------------
namespace FairySpring.UI
{
    public class LookAtCamera : MonoBehaviour
    {
        private bool IsLook = false;
        private GameObject player;
        private void Start()
        {
            player = GameObject.FindWithTag(ProjectConstant.Tag.PLAYER);
        }
        // Update is called once per frame
        void Update()
        {
            if(ProjectConstant.GAME_STATE == GameState.Waiting&&IsLook==false)
            {
                IsLook = true;
                this.transform.SetParent(Camera.main.transform);
                this.transform.LookAt(Camera.main.transform.position);
                Vector3 distance = Camera.main.transform.position - player.transform.position;
                this.transform.position = player.transform.position + distance /3*2;
                //this.transform.position -= (distance);
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if(ProjectConstant.GAME_STATE == GameState.Waiting && IsLook == true)
            {
                this.transform.Rotate(Vector3.forward * 25 * Time.deltaTime, Space.Self);
            }
            else if(ProjectConstant.GAME_STATE == GameState.Fighting)
            {
                this.GetComponent<Fade>().UI_FadeOut_Event();
            }
        }
    }
}
