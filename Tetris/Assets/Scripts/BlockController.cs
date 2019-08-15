using UnityEngine;

public class BlockController : MonoBehaviour
{
    private float lastFall = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (IsValidPosition())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (IsValidPosition())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 0, 90);

            if (IsValidPosition())
            {
                UpdateGrid();
            }
            else
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            transform.Rotate(0, 0, -90);

            if (IsValidPosition())
            {
                UpdateGrid();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }
        }

        if (Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (IsValidPosition())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<GameManager>().InstantiateBlock();

                this.enabled = false;
            }

            lastFall = Time.time;
        }
    }

    private bool IsValidPosition()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            Vector2 childPostion = Grid.DoRoundVector2(child.position);

            if (!Grid.IsInsideBorders(childPostion))
                return false;

            if (Grid.grid[(int)childPostion.x, (int)childPostion.y] != null &&
                                     Grid.grid[(int)childPostion.x, (int)childPostion.y].parent != transform)
                return false;
        }
        return true;
    }

    private void UpdateGrid()
    {
        for (int y = 0; y < Grid.height; y++)
        {
            for (int x = 0; x < Grid.width; x++)
            {
                if (Grid.grid[x, y] != null)
                {
                    if (Grid.grid[x, y].parent == this.gameObject.transform)
                    {
                        Grid.grid[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform child in transform)
        {
            Vector2 childPosition = Grid.DoRoundVector2(child.position);
            Grid.grid[(int)childPosition.x, (int)childPosition.y] = child;
        }
    }
}
