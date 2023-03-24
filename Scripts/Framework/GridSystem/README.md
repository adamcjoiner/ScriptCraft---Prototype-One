# Grid System

The `GridSystem` class provides a way to create a grid-based system in Unity. It includes methods to convert between world positions and grid positions, validate if a grid position is within the grid bounds, place and remove objects on the grid, get the object at a particular grid position, and draw the grid in the Unity editor.

## Usage
To use the `GridSystem`, create a new instance of the class and specify the width, height, cell size, and origin of the grid:

```csharp
GridSystem grid = new GridSystem(10, 10, 1.0f, Vector3.zero);
```

You can then use the various methods provided by the class to interact with the grid. For example, to place an object on the grid, you would use the `PlaceObject` method:

```csharp
public GameObject objectPrefab;

// Place an object at grid position (3, 4)
grid.PlaceObject(objectPrefab, new Vector2Int(3, 4));
```

To remove an object from the grid, you would use the `RemoveObject` method:

```csharp
// Remove the object at grid position (3, 4)
grid.RemoveObject(new Vector2Int(3, 4));
```

To get the object at a particular grid position, you would use the `GetObjectAtGridPosition` method:

```csharp
// Get the object at grid position (3, 4)
GameObject obj = grid.GetObjectAtGridPosition(new Vector2Int(3, 4));
```

To draw the grid in the Unity editor, you can create a new game object with a `GridSystemDrawer` component and set the `gridSystem` property to your `GridSystem` instance. The `GridSystemDrawer` component includes a custom editor that provides a button to draw the grid in the scene view.

## Saving and Loading Grid State

The `GridSystem` also includes methods to serialize and deserialize the state of the grid, allowing you to save and load the state of objects on the grid. To get the current state of the grid, you can use the `GetGridState` method:

```csharp
GridSystem.GridState state = grid.GetGridState();
```

To set the state of the grid, you can use the `SetGridState` method:

``csharp
grid.SetGridState(state);
```

To serialize the state of the grid to a JSON string, you can use the `SerializeGridState` method:

```csharp
string json = grid.SerializeGridState();
```

To deserialize a JSON string and set the state of the grid, you can use the `DeserializeGridState` method:

```csharp
grid.DeserializeGridState(json);
```

Note that you'll need to handle saving and loading the grid state to a file separately, as that code is not included in the `GridSystem` class.