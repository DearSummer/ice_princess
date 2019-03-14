using UnityEngine;

namespace God_SCRIPT.UI
{
    public class UIEffectPlayer : MonoBehaviour {

        private void Awake()
        {
            if (gameObject.GetComponent<RectTransform>() == null)
            {
                RectTransform rt = gameObject.AddComponent<RectTransform>();
                rt.anchorMax = Vector2.zero;
                rt.anchorMin = Vector2.zero;
                rt.anchoredPosition = new Vector2(130, 160);
            }

            SetLayerAndSortOrder(gameObject.transform, 5, 1);
        }

        void SetLayerAndSortOrder(Transform parent, int layer, int sortOrder)
        {
            parent.gameObject.layer = layer;
            ParticleSystem ps = parent.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ParticleSystemRenderer psr = gameObject.GetComponent<ParticleSystemRenderer>();
                if (psr != null)
                {
                    psr.sortingOrder = sortOrder;
                }
            }

            foreach (Transform child in parent)
            {
                SetLayerAndSortOrder(child, layer, sortOrder);
            }
        }

    }
}
