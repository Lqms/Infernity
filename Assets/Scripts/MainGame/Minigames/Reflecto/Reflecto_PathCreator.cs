using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_PathCreator : MonoBehaviour
{
    [Header("Path points")]
    [SerializeField] private Transform[] _direct;
    [SerializeField] private Transform[] _left;
    [SerializeField] private Transform[] _right;
    [SerializeField] private Transform[] _opposite;

    [Header("Path colors")]
    [SerializeField] private Color _directPathColor;
    [SerializeField] private Color _leftPathColor;
    [SerializeField] private Color _rightPathColor;
    [SerializeField] private Color _oppsitePathColor;

    private List<Vector3[]> _paths;
    private Vector3[] _oppositePath, _directPath, _leftPath, _rightPath;

    public Color LastGeneratedPathColor { get; private set; }

    private void Start()
    {
        _directPath = new Vector3[_direct.Length];

        for (int i = 0; i < _directPath.Length; i++)
            _directPath[i] = _direct[i].position;

        _leftPath = new Vector3[_left.Length];

        for (int i = 0; i < _leftPath.Length; i++)
            _leftPath[i] = _left[i].position;

        _rightPath = new Vector3[_right.Length];

        for (int i = 0; i < _rightPath.Length; i++)
            _rightPath[i] = _right[i].position;

        _oppositePath = new Vector3[_opposite.Length];

        for (int i = 0; i < _oppositePath.Length; i++)
            _oppositePath[i] = _opposite[i].position;

        _paths = new List<Vector3[]>() { _directPath, _leftPath, _rightPath, _oppositePath };
    }

    public Vector3[] GetRandomPath()
    {
        var randomPath = _paths[Random.Range(0, _paths.Count)];

        if (randomPath == _directPath)
        {
            LastGeneratedPathColor = _directPathColor;
        }
        else if (randomPath == _oppositePath)
        {
            LastGeneratedPathColor = _oppsitePathColor;
        }
        else if (randomPath == _leftPath)
        {
            LastGeneratedPathColor = _leftPathColor;
        }
        else if (randomPath == _rightPath)
        {
            LastGeneratedPathColor = _rightPathColor;
        }

        return randomPath;
    }
}
