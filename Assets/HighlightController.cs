
using UnityEngine;


public class HighlightController : MonoBehaviour
{
    [SerializeField] private LayerMask _tilesLayerMask;
    
    [SerializeField]
    private float _maxRayDistance = 50f;

    private Camera _camera;
    private Tile _lastHighlightedTile;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
       
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, _maxRayDistance, _tilesLayerMask))
        {
            var tile = hitInfo.collider.gameObject.GetComponent<Tile>();

            HighlightTile(tile);
        }
        else
        {
            ResetLastHighLight();
        }
    }

    private void HighlightTile(Tile tile)
    {
        ResetLastHighLight();

        if (tile != null)
        {
            tile.Highlight(true);
        }

        _lastHighlightedTile = tile;
    }

    private void ResetLastHighLight()
    {
        if (_lastHighlightedTile != null)
        {
            _lastHighlightedTile.Highlight(false);
        }
    }
}
