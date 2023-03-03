using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSlice_VFXController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _trail;

    public void SwitchTrailEnabling(bool state)
    {
        _trail.enableEmission = state;
    }
}
