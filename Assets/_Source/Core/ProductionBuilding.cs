using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class ProductionBuilding : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameManagerObject;

        [SerializeField]
        private GameResource resourceType;

        [SerializeField]
        private float productionTime;

        private Button _button;
        private Slider _slider;

        private ResourceBank _bank;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = gameManagerObject.GetComponent<GameManager>();
            _button = GetComponentInChildren<Button>();
            _slider = GetComponentInChildren<Slider>();
            _slider.gameObject.SetActive(false);
            _bank = _gameManager.ResourceBank;
            _button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick() => StartCoroutine(ProduceResource());

        IEnumerator ProduceResource()
        {
            var calculatedProductionTime = productionTime * (1 - (_gameManager.ResourceProductionLevels[resourceType].Value - 1) / 100f);

            _button.interactable = false;
            _slider.gameObject.SetActive(true);

            float finishTime = Time.time + calculatedProductionTime;

            while (Time.time < finishTime)
            {
                _slider.value = Mathf.Lerp(0, 1, 1 - (finishTime - Time.time) / calculatedProductionTime);
                yield return null;
            }

            _slider.gameObject.SetActive(false);
            _slider.value = 0;
            _bank.ChangeResource(resourceType, 1);
            _button.interactable = true;
        }
    }
}
