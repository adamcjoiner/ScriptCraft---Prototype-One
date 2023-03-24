using UnityEngine;

[] Add Visuals: Add a "View grid" checkbox to UI and a method that draws gridlines into the scene
[] Add Object Placement/Mgmt: Expand to handle objects placed on the grid (i.e. managing instantiation, removal and tracking their state)
[] Add Object Interaction: Methods for interacting with objects, such as selecting, moving and connecting them. Also including grid snapping mechanism.
[] Add Layers: Extend grid system to handle multiple layers (for multifloor buldings)

public class GridSystem
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public float CellSize { get; private set; }
    public Vector3 Origin { get; private set; }

    public GridSystem(int width, int height, float cellSize, Vector3 origin)
    {
        Width = width;
        Height = height;
        CellSize = cellSize;
        Origin = origin;
    }

    // Convert world position to grid coordinates
    public Vector2Int WorldToGrid(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - Origin.x) / CellSize);
        int y = Mathf.FloorToInt((worldPosition.z - Origin.z) / CellSize);

        return new Vector2Int(x, y);
    }

    // Convert grid coordinates to world position
    public Vector3 GridToWorld(Vector2Int gridPosition)
    {
        float x = gridPosition.x * CellSize + CellSize / 2 + Origin.x;
        float z = gridPosition.y * CellSize + CellSize / 2 + Origin.z;

        return new Vector3(x, 0, z);
    }

    // Validate if a grid position is within the grid bounds
    public bool IsGridPositionValid(Vector2Int gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.x < Width && gridPosition.y >= 0 && gridPosition.y < Height;
    }
}
