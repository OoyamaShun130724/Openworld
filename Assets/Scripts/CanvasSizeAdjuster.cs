using UnityEngine;
using UnityEngine.UI;

public class CanvasSizeAdjuster : MonoBehaviour
{
    [SerializeField] int _x;
    [SerializeField] int _y;
    private void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        RectTransform rectTransform = canvas.GetComponent<RectTransform>();

        rectTransform.localScale = new Vector2(_x, _y);
    }
}