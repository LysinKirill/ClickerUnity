using System.Collections.Generic;

namespace Core
{
    public class ResourceBank
    {
        public Dictionary<GameResource, ObservableInt> ResourcesDictionary { get; } = new Dictionary<GameResource, ObservableInt>
        {
            { GameResource.Humans, new ObservableInt(0) },
            { GameResource.Food, new ObservableInt(0) },
            { GameResource.Wood, new ObservableInt(0) },
            { GameResource.Stone, new ObservableInt(0) },
            { GameResource.Gold, new ObservableInt(0) },
        };

        public void ChangeResource(GameResource r, int v)
        {
            if (!ResourcesDictionary.ContainsKey(r))
                ResourcesDictionary[r] = new ObservableInt(0);
            ResourcesDictionary[r].Value += v;
        }

        public ObservableInt GetResource(GameResource r) => ResourcesDictionary[r];

    }
}
