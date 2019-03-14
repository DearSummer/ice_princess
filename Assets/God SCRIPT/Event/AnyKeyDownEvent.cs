using UnityEngine;
using UnityEngine.Events;

namespace God_SCRIPT.Event
{
    public class AnyKeyDownEvent : MonoBehaviour
    {


        public UnityEvent OnAnyKeyDown;

	
        // Update is called once per frame
        void Update () {
            if (Input.anyKeyDown)
            {
                OnAnyKeyDown.Invoke();
            }
        }
    }
}
