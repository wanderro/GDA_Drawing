using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    [SerializeField] private Collider _blackboardCollider;
    [SerializeField] private float _rayDistance = 100;

    private Material _cursorMaterial;
    private LineRenderer _lineRenderer;
    private Camera _mainCamera;

    private void Awake()
    {
        _cursorMaterial = GetComponent<MeshRenderer>().material;
        _lineRenderer = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
    }

    private void OnDisable()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
    
    public void SetColor(Color color)
    {
        _cursorMaterial.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }

    private void Update()
    {
        var mousePosition = Input.mousePosition;
        var ray = _mainCamera.ScreenPointToRay(mousePosition);

        if (!_blackboardCollider.Raycast(ray, out var hitInfo, _rayDistance)) return;

        var blackboardPoint = hitInfo.point;
        transform.position = blackboardPoint;

        if (!Input.GetMouseButton(0) || _lineRenderer == null) return;

        var index = ++_lineRenderer.positionCount - 1;
        _lineRenderer.SetPosition(index, blackboardPoint);
    }

}