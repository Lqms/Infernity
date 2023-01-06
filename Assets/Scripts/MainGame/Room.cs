using UnityEngine;
using System.Linq;

public class Room : MonoBehaviour
{
    [SerializeField] private Door[] _doors;

    private bool[] _doorStates = { true, false };

    public Door BurnedDoor { get; private set; }

    public void Init(DoorSides oppositeDoorSide)
    {
        foreach (Door door in _doors)
            if (oppositeDoorSide == door.Side)
                BurnedDoor = door;

        BurnedDoor.SwitchState(false);
        BurnedDoor.BurnVFX.Play();

        Generate();
    }

    private void Generate()
    {
        var allDoorsExceptBurned = _doors.Where(door => door != BurnedDoor).ToList();

        foreach (var door in allDoorsExceptBurned)
        {
            int randomIndex = Random.Range(0, _doorStates.Length);
            bool state = _doorStates[randomIndex];
            door.SwitchState(state);
        }

        var closedDoors = allDoorsExceptBurned.Where(door => door.Enabled == false).ToList();

        if (closedDoors.Count == allDoorsExceptBurned.Count)
        {
            int randomIndex = Random.Range(0, allDoorsExceptBurned.Count);
            allDoorsExceptBurned[randomIndex].SwitchState(true);
        }
    }
}
