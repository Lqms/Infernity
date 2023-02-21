using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_PathCreator : MonoBehaviour
{ 
    [SerializeField] private Transform[] _direct;
    [SerializeField] private Transform[] _left;
    [SerializeField] private Transform[] _right;
    [SerializeField] private Transform[] _opposite;

    private List<Vector3[]> _paths;

    private void Start()
    {
        var directPath = new Vector3[_direct.Length];

        for (int i = 0; i < directPath.Length; i++)
            directPath[i] = _direct[i].position;

        var leftPath = new Vector3[_left.Length];

        for (int i = 0; i < leftPath.Length; i++)
            leftPath[i] = _left[i].position;

        var rightPath = new Vector3[_right.Length];

        for (int i = 0; i < rightPath.Length; i++)
            rightPath[i] = _right[i].position;

        var oppositePath = new Vector3[_opposite.Length];

        for (int i = 0; i < oppositePath.Length; i++)
            oppositePath[i] = _opposite[i].position;

        _paths = new List<Vector3[]>() { directPath, leftPath, rightPath, oppositePath };
    }

    public Vector3[] GetRandomPath()
    {
        return _paths[Random.Range(0, _paths.Count)];
    }
}
