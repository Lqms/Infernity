using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerClickHandler))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;

    [Header("Animations")]
    [SerializeField] private Animator _idleAnimator;
    [SerializeField] private Animator _runAnimator;
    [SerializeField] private Animator _attackAnimator;

    private Animator _currentAnimator;

    public float CurrentAnimationTime { get; private set; }

    private const string AttackSpeed = nameof(AttackSpeed);
    private const string StartAttack = nameof(StartAttack);

    private void Start()
    {
        _currentAnimator = _idleAnimator;
        _currentAnimator.gameObject.SetActive(true);
    }

    private void RunAttack(float attackSpeed)
    {
        _attackAnimator.SetFloat(AttackSpeed, attackSpeed);
        _attackAnimator.SetTrigger(StartAttack);

        var currentAnimatorStateInfo = _attackAnimator.GetCurrentAnimatorStateInfo(0);
        CurrentAnimationTime = currentAnimatorStateInfo.length / currentAnimatorStateInfo.speedMultiplier;
        print(CurrentAnimationTime);      
    }


    private void Update()
    {
        if (_controller.IsAttacking)
        {
            ChangeCurrentAnimator(_attackAnimator);
            RunAttack(_controller.AttackSpeed);
        }
        else if (_controller.IsMoving)
        {
            ChangeCurrentAnimator(_runAnimator);
        }
        else
        {
            ChangeCurrentAnimator(_idleAnimator);
        }
    }

    private void ChangeCurrentAnimator(Animator newAnimator)
    {
        if (newAnimator.gameObject.activeSelf == true)
            return;

        _currentAnimator.gameObject.SetActive(false);
        _currentAnimator = newAnimator;
        _currentAnimator.gameObject.SetActive(true);
    }
}
