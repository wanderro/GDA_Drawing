using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    private DrawingController _drawingController;
    [SerializeField]
    private LineDrawing _lineDrawing;

    private void Start()
    {
        var imageColor = GetComponent<Image>().color;
        _lineDrawing.SetColor(imageColor);
    }

    public void ActivateChosenLineDrawing()
    {
        _drawingController.DisableDrawings();
        _lineDrawing.enabled = true;
    }
}
