using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSlice_Player : MonoBehaviour
{
    [SerializeField] private ImpSlice_Pointer _pointer;
    [SerializeField] private ImpSlice_VFXController _vfxController;

    [Header("Animations")]
    [SerializeField] public Animator _attackAnimation;

    private void OnEnable()
    {
        _pointer.SliceStarted += OnSliceStarted;
        _pointer.SliceStopped += OnSliceStopped;
    }

    private void OnDisable()
    {
        _pointer.SliceStarted -= OnSliceStarted;
        _pointer.SliceStopped -= OnSliceStopped;
    }

    private void OnSliceStarted()
    {
        _vfxController.SwitchTrailEnabling(true);
    }

    private void OnSliceStopped()
    {
        _vfxController.SwitchTrailEnabling(false);

        StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        _attackAnimation.gameObject.SetActive(true);

        yield return new WaitForSeconds(_attackAnimation.GetCurrentAnimatorStateInfo(0).length);

        _attackAnimation.gameObject.SetActive(false);
    }
}
