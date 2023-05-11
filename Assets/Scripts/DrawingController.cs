using System.Collections.Generic;
using UnityEngine;

public class DrawingController : MonoBehaviour
{
    [SerializeField]
    private List<LineDrawing> _lineDrawingsList;

    public void DisableDrawings()
    {
        foreach (var drawing in _lineDrawingsList)
        {
            drawing.enabled = false;
        }
    }

    public void ClearBlackboard()
    {
        var lineRenderers = GetComponentsInChildren<LineRenderer>();
        foreach (var renderer in lineRenderers)
        {
            renderer.positionCount = 0;
        }
    }
}
