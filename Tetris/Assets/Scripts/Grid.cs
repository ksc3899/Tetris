using UnityEngine;

public class Grid : MonoBehaviour
{
    public static int width = 8;
    public static int height = 6;
    public static Transform[,] grid = new Transform[width, height];

    public static bool IsInsideBorders(Vector2 position)
    {
        return ((int)position.x >= -0.5f && (int)position.x < width && (int)position.y >= 0f);
    }

    public static Vector2 DoRoundVector2(Vector2 vector2)
    {
        return new Vector2(Mathf.Round(vector2.x), Mathf.Round(vector2.y));
    }
}