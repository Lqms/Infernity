using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _baseRotation = new Vector3(90, 0, 0);
    [SerializeField] private Vector3 _basePosition = new Vector3(0, 10, 0);

    private void Start()
    {
        transform.position = _basePosition;
        transform.eulerAngles = _baseRotation;

        TopDownFollow(_target, _basePosition.y);
    }

    public void TopDownFollow(Transform target, float offsetY)
    {
        StartCoroutine(TopDownFollowing(target, offsetY));
    }

    public void SetCameraStaticView(Vector3 position, Vector3 rotation)
    {
        StopAllCoroutines();

        transform.eulerAngles = rotation;
        transform.position = position;
    }

    private IEnumerator TopDownFollowing(Transform target, float offsetY)
    {
        while (true)
        {
            yield return null;
            transform.position = new Vector3(target.position.x, offsetY, target.position.z);
        }
    }
}
