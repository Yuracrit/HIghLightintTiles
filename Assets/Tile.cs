using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Highlight(bool isHighlighter)
    {
        _renderer.material.color = isHighlighter ? Color.gray : Color.white;
    }

    
}