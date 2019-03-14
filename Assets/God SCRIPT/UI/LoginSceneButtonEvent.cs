using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace God_SCRIPT.UI
{
    public class LoginSceneButtonEvent : MonoBehaviour {

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

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
