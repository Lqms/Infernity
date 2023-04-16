using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigamePerksList : MonoBehaviour
{
    [SerializeField] private List<string> _perks = new List<string>() { "abc", "def", "ghi", "ikj" };

    public List<string> Perks => _perks;

    public event UnityAction Changed;

    public void ChangeList(string perk, bool isAdded)
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
