using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerksPoolTest : MonoBehaviour
{
    [SerializeField] private List<MinigamePerkData> _perksData;

    public MinigamePerkData GetRandomPerk()
    {
        var perk = _perksData[Random.Range(0, _perksData.Count)];
        _perksData.Remove(perk);

        return perk;
    }
}
