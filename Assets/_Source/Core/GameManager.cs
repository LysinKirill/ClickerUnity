using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private ResourceBank _resourceBank;

        public ResourceBank ResourceBank
        {
            get { return _resourceBank; }
        }

        private void Awake()
        {
            _resourceBank = new ResourceBank();

            _resourceBank.ChangeResource(GameResource.Humans, 10);
            _resourceBank.ChangeResource(GameResource.Food, 5);
            _resourceBank.ChangeResource(GameResource.Wood, 5);
        }
    }

}
