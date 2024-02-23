using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class FakeLoading : MonoBehaviour
    {
        [SerializeField] private Image loadingProgressImage;
        [SerializeField] private GameObject panel;
        private float fillAmount = 0;

        private void Awake()
        {
            panel.SetActive(true);
        }
        
        void Update()
        {
            fillAmount += Random.Range(0, Time.deltaTime * 2);
            if (fillAmount >= 0.9)
            {
                loadingProgressImage.fillAmount = 1;
                Destroy(panel);
                Destroy(gameObject);
            }

            loadingProgressImage.fillAmount = fillAmount;
        }

    }
}
