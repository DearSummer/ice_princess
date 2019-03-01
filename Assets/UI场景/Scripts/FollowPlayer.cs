using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
//-------------------------------------------
//  author: 
//  description:  
//-------------------------------------------
namespace FairySpring
{
    public class FollowPlayer : MonoBehaviour
    {

        private GameObject player;
        public Vector3 offset = new Vector3(-0.2173055f, 2.476311f, -3.444581f);

        private float smooth = 3;
        // Use this for initialization
        void Start()
        {
            player = GameObject.FindWithTag(ProjectConstant.Tag.PLAYER);
            offset = new Vector3(-0.2173055f, 2.476311f, -3.444581f);
        }

        void LateUpdate()
        {
            Vector3 lookAtPos = HandlerLookAtPos();
            transform.position = Vector3.Lerp(transform.position,
                lookAtPos + player.transform.TransformDirection(offset), Time.deltaTime * smooth);
            transform.LookAt(lookAtPos);
        }

        private Vector3 HandlerLookAtPos()
        {
            if (ProjectConstant.GAME_STATE == GameState.Normal)
            {
                offset = new Vector3(-0.2173055f, 2.476311f, -3.444581f);
                return player.transform.position;
            }

            switch (ProjectConstant.GAME_STATE)
            {
              
                case GameState.Waiting:
                {
                    smooth = 3;
                    Vector3 center = CalculateCenterPos();
                    offset = (player.transform.position - center)*0.01f;
                    return player.transform.position+new Vector3(0f,1.0f,0.0f);
                }
                case GameState.Fighting:
                {
                    smooth = 3;
                    Vector3 center = CalculateCenterPos();
                    offset = new Vector3(5.2173055f, 3.476311f, 1.444581f);
                    return center;
                }
            }
            return Vector3.zero;
        }

        private Vector3 CalculateCenterPos()
        {
            GameObject[] enmeys = GameObject.FindGameObjectsWithTag(ProjectConstant.Tag.ACTIVE_ENEMY);
            List<Vector3> centerPosList = new List<Vector3>();
            foreach (var enemy in enmeys)
            {
                Vector3 centerPos = (enemy.transform.position + player.transform.position) / 2;
                centerPosList.Add(centerPos);
            }

            Vector3 center = Vector3.zero;
            if (centerPosList.Count > 1)
            {

                foreach (var pos in centerPosList)
                {
                    center += pos;
                }

                center = center / 2;
            }
            else if(centerPosList.Count==1)
            {
                center = centerPosList[0];
            }
            else if(centerPosList.Count==0)
            {

            }
            return center;
        }
    }
}

