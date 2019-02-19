using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnimatorScript
{
    public class AnimatorInfo
    {
        private static AnimatorInfo instance;
        public static AnimatorInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnimatorInfo();

                }
                return instance;
            }
            set { }
        }
        private AnimatorInfo()
        {

        }
        public bool Run = false;
    }
}

