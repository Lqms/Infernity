using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ImpSlice_Pointer : MonoBehaviour
{
    [SerializeField] private float _maxSlicingDistance = 1000;
    [SerializeField] private float _maxSliceTimer = 1;
    [SerializeField] private Collider _collider;

    private Vector3 _startSlicingMousePosition;
    private Coroutine _coroutine;
    private bool _isSlicing;

    private const float DistanceFromCamera = 10;

    public event UnityAction SliceStarted;
    public event UnityAction SliceStopped;

    private void Update()
    {
        if (_isSlicing)
            MoveToMouse();

        if (Input.GetMouseButtonDown(0))
            StartSlice();
        else if (Input.GetMouseButtonUp(0))
            StopSlice();
    }

    private void MoveToMouse()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, DistanceFromCamera);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }

    private void StopSlice()
    {
        SliceStopped?.Invoke();
        SwitchSliceState(false);
    }

    private void SwitchSliceState(bool state)
    {
        _isSlicing = state;
        _collider.enabled = state;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void StartSlice()
    {
        SliceStarted?.Invoke();

        SwitchSliceState(true);
        _startSlicingMousePosition = Input.mousePosition;
        _coroutine = StartCoroutine(Slicing(_maxSliceTimer));
    }

    private IEnumerator Slicing(float timer)
    {
        yield return new WaitForSeconds(0.1f);

        while (Vector3.Distance(Input.mousePosition, _startSlicingMousePosition) < _maxSlicingDistance && timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        StopSlice();
    }
}
