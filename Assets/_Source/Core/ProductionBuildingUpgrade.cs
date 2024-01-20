using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class ProductionBuildingUpgrade : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameManagerObject;

        [SerializeField]
        private GameResource resourceType;

        private Button _button;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = gameManagerObject.GetComponent<GameManager>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);

        }

        public void OnButtonClick() => UpgradeResourceBuilding();

        void UpgradeResourceBuilding()
        {
            ++_gameManager.ResourceProductionLevels[resourceType].Value;
            if (_gameManager.ResourceProductionLevels[resourceType].Value >= 100)
                _button.interactable = false;
        }
    }
}
