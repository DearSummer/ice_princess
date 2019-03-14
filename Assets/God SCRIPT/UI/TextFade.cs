using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace God_SCRIPT.UI
{
    public class TextFade : MonoBehaviour
    {

        private Text text;

        [SerializeField]
        private Color targetColor;

        // Use this for initialization
        void Start ()
        {
            text = GetComponent<Text>();
            text.DOColor(targetColor, 2.5f).SetLoops(-1,LoopType.Yoyo);
        }
	

        
    }
}
