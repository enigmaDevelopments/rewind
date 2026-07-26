using UnityEngine;

public class Frame : MonoBehaviour
{
    public float bottom;
    public float top;
    public float left;
    public float right;
    public SpriteRenderer spriteRenderer;
    void Update()
    {
        float x = (left + right) / 2;
        float y = (bottom + top) / 2;
        float height = top - bottom;
        float width = right - left;
        float aspectRatio = Screen.width / ((float)Screen.height);
        float widthRatio = width / aspectRatio;

        transform.position = new Vector3(x, y, -10);
        

        if (height < widthRatio)
        {
            gameObject.GetComponent<Camera>().orthographicSize = widthRatio / 2;
            spriteRenderer.size = new Vector2(width, widthRatio);
        }
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = height / 2;
            spriteRenderer.size = new Vector2(height * aspectRatio, height);
        }

    }

}
