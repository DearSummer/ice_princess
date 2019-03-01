using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


//-------------------------------------------
//  author: 
//  description:  
//-------------------------------------------
namespace FairySpring
{
    public class ActiveScene : MonoBehaviour
    {
      
        private AsyncOperation asyncOperation;

        void Update()
        {
            if (asyncOperation == null)
                return;

            
            
        }


        public void LoadScene(string sceneName)
        {
            StartCoroutine("LoadNewScene",sceneName);
        }

        private IEnumerator LoadNewScene(string sceneName)
        {
            yield return new WaitForEndOfFrame();
            asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            yield return asyncOperation;


        }


    }
}
