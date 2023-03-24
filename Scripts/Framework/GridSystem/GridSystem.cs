using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[x] Add Visuals: Add a "View grid" checkbox to UI and a method that draws gridlines into the scene
[x] Add Object Placement/Mgmt: Expand to handle objects placed on the grid (i.e. managing instantiation, removal and tracking their state)
[] Add Object Interaction: Methods for interacting with objects, such as selecting, moving and connecting them. Also including grid snapping mechanism.
[] Add Layers: Extend grid system to handle multiple layers (for multifloor buldings)

public class GridSystem
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public float CellSize { get; private set; }
    public Vector3 Origin { get; private set; }
    private GameObject[,] gridObjects;

    public GridSystem(int width, int height, float cellSize, Vector3 origin)
    {
        Width = width;
        Height = height;
        CellSize = cellSize;
        Origin = origin;
        gridObjects = new GameObject[width, height];
    }

    public Vector2Int WorldToGrid(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - Origin.x) / CellSize);
        int y = Mathf.FloorToInt((worldPosition.z - Origin.z) / CellSize);

        return new Vector2Int(x, y);
    }

    public Vector3 GridToWorld(Vector2Int gridPosition)
    {
        float x = gridPosition.x * CellSize + CellSize / 2 + Origin.x;
        float z = gridPosition.y * CellSize + CellSize / 2 + Origin.z;

        return new Vector3(x, 0, z);
    }

    public bool IsGridPositionValid(Vector2Int gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.x < Width && gridPosition.y >= 0 && gridPosition.y < Height;
    }

    public bool PlaceObject(GameObject objectPrefab, Vector2Int gridPosition)
    {
        if (IsGridPositionValid(gridPosition) && gridObjects[gridPosition.x, gridPosition.y] == null)
        {
            Vector3 worldPosition = GridToWorld(gridPosition);
            GameObject newObject = Object.Instantiate(objectPrefab, worldPosition, Quaternion.identity);
            gridObjects[gridPosition.x, gridPosition.y] = newObject;
            return true;
        }
        return false;
    }

    public void RemoveObject(Vector2Int gridPosition)
    {
        if (IsGridPositionValid(gridPosition) && gridObjects[gridPosition.x, gridPosition.y] != null)
        {
            Object.Destroy(gridObjects[gridPosition.x, gridPosition.y]);
            gridObjects[gridPosition.x, gridPosition.y] = null;
        }
    }

    public GameObject GetObjectAtGridPosition(Vector2Int gridPosition)
    {
        if (IsGridPositionValid(gridPosition))
        {
            return gridObjects[gridPosition.x, gridPosition.y];
        }
        return null;
    }

    public void DrawGrid()
    {
        Gizmos.color = Color.white;
        for (int x = 0; x <= Width; x++)
        {
            Vector3 startPos = GridToWorld(new Vector2Int(x, 0));
            Vector3 endPos = GridToWorld(new Vector2Int(x, Height));
            Gizmos.DrawLine(startPos, endPos);
        }
        for (int y = 0; y <= Height; y++)
        {
            Vector3 startPos = GridToWorld(new Vector2Int(0, y));
            Vector3 endPos = GridToWorld(new Vector2Int(Width, y));
            Gizmos.DrawLine(startPos, endPos);
        }
        Gizmos.color = Color.red;
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector2Int gridPos = new Vector2Int(x, y);
                Vector3 worldPos = GridToWorld(gridPos);
                string cellId = $"{x+1}{(char)(y+65)}";
                Handles.Label(worldPos, cellId, GUI.skin.box);
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GridSystemDrawer))]
public class GridSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GridSystemDrawer gridSystemDrawer = (GridSystemDrawer)target;
        if (GUILayout.Button("Draw Grid"))
        {
            SceneView.RepaintAll();
        }
    }

    private void OnSceneGUI()
    {
        GridSystemDrawer gridSystemDrawer = (GridSystemDrawer)target;
        if (gridSystemDrawer.gridSystem != null)
        {
            gridSystemDrawer.gridSystem.DrawGrid();
        }
    }
}
#endif
