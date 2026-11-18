using UnityEngine;

public class curser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RectTransform Cursorimage;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Cursorimage.parent.GetComponent<RectTransform>(), Input.mousePosition, null, out position);

        Cursorimage.anchoredPosition = position;
    }
}
