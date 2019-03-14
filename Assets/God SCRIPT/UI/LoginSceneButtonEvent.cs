using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace God_SCRIPT.UI
{
    public class LoginSceneButtonEvent : MonoBehaviour {


        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
