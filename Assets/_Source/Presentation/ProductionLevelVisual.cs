using TMPro;
using UnityEngine;


namespace Core
{
    public class ProductionLevelVisual : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private GameResource resource;

        private TMP_Text _buttonText;

        private void Awake()
        {
            _buttonText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            var productionLevels = gameManager.ResourceProductionLevels;

            productionLevels[resource].OnValueChanged = val => _buttonText.text = $"Lvl {val}";
            productionLevels[resource].OnValueChanged.Invoke(1);
        }
    }
}
