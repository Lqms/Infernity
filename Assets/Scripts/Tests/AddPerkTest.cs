using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPerkTest : MonoBehaviour
{
    [SerializeField] private MinigamePerksList _perksList;
    [SerializeField] private PerksPoolTest _pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            AddNewPerk();
    }

    private void AddNewPerk()
    {
        var newPerk = _pool.GetRandomPerk();
        print(newPerk);
        _perksList.AddPerk(newPerk);
    }
}
