using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reflecto_PlayerHealth : MonoBehaviour
{
    private float _health;

    private void OnEnable()
    {
        _health = PlayerStats.Health;
    }

    public void ApplyDamage(float amount)
    {
        _health = Mathf.Clamp(_health - amount, 0, _health);

        if (_health <= 0)
        {
            print("ded");
            SceneManager.LoadScene(0);
        }
    }
}
