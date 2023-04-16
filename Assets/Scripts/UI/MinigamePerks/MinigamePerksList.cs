using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigamePerksList : MonoBehaviour
{
    [SerializeField] private List<MinigamePerkData> _perks;

    public List<MinigamePerkData> Perks => _perks;

    public event UnityAction Changed;

    public void ChangeList(MinigamePerkData perk, bool isAdded)
    {
        if (isAdded)
        {
            Perks.Add(perk);
        }
        else
        {
            Perks.Remove(perk);
        }

        Changed?.Invoke();
    }
}
