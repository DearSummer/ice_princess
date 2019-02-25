using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PackageScript
{
    public class Package : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = (Time.timeScale - 1) == 0 ? 0 : 1;
            }
        }
    }
}

