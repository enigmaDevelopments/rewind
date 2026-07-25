using UnityEngine;

public class Frame : MonoBehaviour
{
    public float bottom;
    public float top;
    public float left;
    public float right;
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
            gameObject.GetComponent<Camera>().orthographicSize = widthRatio / 2;
        else
            gameObject.GetComponent<Camera>().orthographicSize = height / 2;
    }
}
