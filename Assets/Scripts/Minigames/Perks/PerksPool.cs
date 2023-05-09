using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerksPool : MonoBehaviour
{
    [SerializeField] private List<MinigamePerkData> _perksData;

    public MinigamePerkData GetRandomPerk()
    {
        int random = Random.Range(0, 100);
        int requiredRarity;

        if (random >= 0 && random < 50)
            requiredRarity = 0;
        else if (random >= 50 && random < 75)
            requiredRarity = 1;
        else if (random >= 75 && random < 90)
            requiredRarity = 2;
        else
            requiredRarity = 3;

        var filteredPerks = _perksData.Where(p => (int)p.Rarity == requiredRarity).ToList();
        var newPerk = filteredPerks[Random.Range(0, filteredPerks.Count)];

        // _perksData.Remove(newPerk);

        return newPerk;
    }
}
