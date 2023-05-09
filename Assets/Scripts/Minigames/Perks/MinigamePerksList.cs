using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigamePerksList : MonoBehaviour
{
    private List<MinigamePerkData> _perks = new List<MinigamePerkData>();

    public List<MinigamePerkData> Perks => _perks;

    public event UnityAction Changed;

    public void AddPerk(MinigamePerkData data)
    {
        _perks.Add(data);
        Changed?.Invoke();
    }

    public void RemovePerk(MinigamePerkData data)
    {
        _perks.Remove(data);
        Changed?.Invoke();
    }
}