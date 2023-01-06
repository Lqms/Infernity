using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 10;
    [SerializeField] private float _moveSpeed = 10;

    private NavMeshAgent _agent;
    private Coroutine _movingCoroutine;

    public Vector3 Velocity => _agent.velocity;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _moveSpeed;
    }

    public void MoveToPoint(Vector3 point)
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _movingCoroutine = StartCoroutine(MovingToPoint(point));
    }

    private IEnumerator MovingToPoint(Vector3 point)
    {
        _agent.SetDestination(point);

        while (Vector3.Distance(transform.position, point) > _agent.radius)
            yield return null;

        _movingCoroutine = null;
    }

    public void StopMoving()
    {
        if (_movingCoroutine != null)
            StopCoroutine(_movingCoroutine);

        _agent.SetDestination(transform.position);
        _agent.velocity = Vector3.zero;
    }
    
    public void RotateToPoint(Vector3 point)
    {
        transform.DOLookAt(point, 1/_rotateSpeed);
    }

    public void Teleportate(Vector3 position)
    {
        transform.position = position;
        _movingCoroutine = StartCoroutine(MovingToPoint(transform.forward));
    }
}
