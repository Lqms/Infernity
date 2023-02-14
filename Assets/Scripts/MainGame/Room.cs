using UnityEngine; 

public class Room : MonoBehaviour
{
    [SerializeField] private Portal[] _portals;
    [SerializeField] private Transform _enterPortal;
    [SerializeField] private Transform _player;

    private void OnEnable()
    {
        print(gameObject.name);
        _player.position = _enterPortal.position;

        foreach (var portal in _portals)
            portal.gameObject.SetActive(false);
    }

    private void GeneratePortals()
    {
        int counter = 0;

        foreach (var portal in _portals)
        {
            int activePortal = Random.Range(0, 2);
            counter += activePortal;
            portal.gameObject.SetActive(System.Convert.ToBoolean(activePortal));
        }

        if (counter == 0)
            _portals[Random.Range(0, _portals.Length)].gameObject.SetActive(true);
    }
}
