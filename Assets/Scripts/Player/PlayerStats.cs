using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float MovementSpeed { get; private set; } = 100;
    public static float AttackSpeed { get; private set; } = 200;
    public static int Level { get; private set; } = 1;
    public static float Health { get; private set; } = 10;
}
