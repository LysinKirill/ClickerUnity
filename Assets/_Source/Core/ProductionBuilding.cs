using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class ProductionBuilding : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameManager;

        [SerializeField]
        private GameResource resourceType;

        [SerializeField]
        private float productionTime;

        private Button _button;
        private Slider _slider;

        private ResourceBank _bank;

        private void Start()
        {
            _button = GetComponentInChildren<Button>();
            _slider = GetComponentInChildren<Slider>();
            _slider.gameObject.SetActive(false);
            _bank = gameManager.GetComponent<GameManager>().ResourceBank;
            _button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick() => StartCoroutine(ProduceResource());

        IEnumerator ProduceResource()
        {
            _button.interactable = false;
            _slider.gameObject.SetActive(true);

            float finishTime = Time.time + productionTime;

            while (Time.time < finishTime)
            {
                _slider.value = Mathf.Lerp(0, 1, 1 - (finishTime - Time.time) / productionTime);
                yield return null;
            }

            _slider.gameObject.SetActive(false);
            _slider.value = 0;
            _bank.ChangeResource(resourceType, 1);
            _button.interactable = true;
        }
    }
}
