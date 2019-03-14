using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace God_SCRIPT.Event
{
    public class OnSceneLoadedEvent : MonoBehaviour
    {

        public UnityEvent OnSceneStartLoad, OnSceneLoaded;
        public FUnityEvent OnSceneLoading;

        private bool isLoading = false;
        public void LoadScene(int level)
        {
            if (!isLoading)
                StartCoroutine(Load(level));
        }

        private IEnumerator Load(int level)
        {
            isLoading = true;
            OnSceneStartLoad.Invoke();
            AsyncOperation operation = SceneManager.LoadSceneAsync(level);
            operation.allowSceneActivation = false;
            while (operation.progress < 0.9f)
            {
                OnSceneLoading.Invoke(operation.progress);
                yield return new WaitForEndOfFrame();
            }

            int progress = (int)(operation.progress * 100);
            while (progress < 100)
            {
                progress++;
                OnSceneLoading.Invoke((float)progress / 100);
                yield return new WaitForEndOfFrame();
            }

            operation.allowSceneActivation = true;
            OnSceneLoaded.Invoke();

            isLoading = false;
        }
    }
}
