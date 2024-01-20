using TMPro;
using UnityEngine;


namespace Core
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private GameResource resource;



        private void Start()
        {
            ResourceBank bank = gameManager.ResourceBank;

            bank.GetResource(resource).OnValueChanged = val =>
                GetComponent<TMP_Text>().text = $"{val}";
            
            bank.ChangeResource(resource, 0); // Initial update
        }
    }
}
