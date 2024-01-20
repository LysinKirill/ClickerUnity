using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {

        public ResourceBank ResourceBank { get; private set; }

        public Dictionary<GameResource, ObservableInt> ResourceProductionLevels { get; private set; }

        void Awake()
        {
            ResourceBank = new ResourceBank();

            ResourceBank.ChangeResource(GameResource.Humans, 10);
            ResourceBank.ChangeResource(GameResource.Food, 5);
            ResourceBank.ChangeResource(GameResource.Wood, 5);

            ResourceProductionLevels = new Dictionary<GameResource, ObservableInt>
            {
                { GameResource.Humans, new ObservableInt(1) },
                { GameResource.Food, new ObservableInt(1) },
                { GameResource.Wood, new ObservableInt(1) },
                { GameResource.Stone, new ObservableInt(1) },
                { GameResource.Gold, new ObservableInt(1) },
            };
        }
    }

}
