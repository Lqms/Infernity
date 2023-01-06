using UnityEngine;

public class PlayerClickHandler : MonoBehaviour
{
    public RaycastHit HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);

        return hitInfo;
    }
}
