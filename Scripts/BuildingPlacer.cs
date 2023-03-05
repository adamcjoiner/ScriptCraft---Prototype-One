using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    private bool currentlyPlacing;
    private BuildingPreset curBuildingPreset;

    private float placementIndicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curPlacementPos;

    public GameObject placementIndicator;
    public float moveSpeed;
    public static BuildingPlacer inst;

    void Awake ()
    {
        inst = this;
    }

    public void BeginNewBuildingPlacement (BuildingPreset buildingPreset)
    {
        if(City.inst.money < buildingPreset.cost)
            return;

        currentlyPlacing = true;
        curBuildingPreset = buildingPreset; // The current building we're working with

        // Set the placement indicator to the blueprint prefab of this model
        GameObject blueprintObj = Instantiate(curBuildingPreset.blueprintPrefab, curPlacementPos, Quaternion.identity) as GameObject;
        blueprintObj.transform.parent = placementIndicator.transform;
        placementIndicator.SetActive(true);
    }

    public void CancelBuildingPlacement ()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    void PlaceBuilding ()
    {
        GameObject buildingObj = Instantiate(curBuildingPreset.prefab, curPlacementPos, Quaternion.identity);
        City.inst.OnPlaceBuilding(curBuildingPreset);

        CancelBuildingPlacement();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            CancelBuildingPlacement();

        if(Time.time - lastUpdateTime > placementIndicatorUpdateRate && currentlyPlacing)
        {
            Debug.Log("Current Placement Indicator Prefab: " + placementIndicator);
            lastUpdateTime = Time.time;

            curPlacementPos = Selector.inst.GetCurTilePosition();
            // placementIndicator.transform.position = curPlacementPos;
            placementIndicator.transform.position = Vector3.Lerp(placementIndicator.transform.position, curPlacementPos, moveSpeed * Time.deltaTime);
        }

        if(currentlyPlacing && Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }
}
