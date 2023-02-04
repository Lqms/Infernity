using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Coroutine _comboAttacksCoroutine;

    public int CurrentAttackIndex { get; private set; }

    public void MakeCombo(int maxLength)
    {
        if (_comboAttacksCoroutine == null)
        {
            CurrentAttackIndex = 0;
        }
        else
        {
            CurrentAttackIndex++;

            if (CurrentAttackIndex >= maxLength)
                CurrentAttackIndex = 0;

            StopCoroutine(_comboAttacksCoroutine);
        }

        _comboAttacksCoroutine = StartCoroutine(ComboTimeCounting());
    }

    private IEnumerator ComboTimeCounting()
    {
        yield return new WaitForSeconds(Constants.ComboAttackBaseTimer / (Constants.PlayerComboAttackRateCoeff + PlayerStats.AttackSpeed * Constants.PlayerAttackSpeedCoeff));

        CurrentAttackIndex = 0;
        _comboAttacksCoroutine = null;
    }
}
