using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectOutline : Outliner
{
    private void OnMouseEnter()
    {
        OutlineWidth = 10;
    }

    private void OnMouseExit()
    {
        OutlineWidth = 0;
    }
}
