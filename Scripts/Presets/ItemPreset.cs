using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/***
*
* Defines resource items
*
* These are created by:
*   - mining a resource
*   - refining a resource item (from above) in refiner
*   - combining combinations of above in Chemistry Chamber
*
*/

public enum ItemType
{
    Resource, // Resource nodes (Trees, Iron Deposit, Copper Deposit, etc.)
    Material, // Resources mined from nodes/Refined materials/Components (Copper Ore/Copper Ingot/Copper Wire)
    Machine
}

[CreateAssetMenu(fileName = "Item Preset", menuName = "New Item Type")]
public class ItemPreset : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public GameObject prefab;
    public ItemType type;
    public Sprite icon;
    public float interactionRange = 4;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;


    // Don't need this. Create new types for each instead:
    // public enum type {
    //     Foliage,
    //     Cellulose,
    //     WoodPlanks,
    //     CarbonIngot,
    //     CarbonFiber,
    //     Resin,
    //     Plastic,
    //     BauxiteOre,
    //     BauxiteIngot,
    //     AlluminumIngot,
    //     CopperOre,
    //     CopperIngot,
    //     Quartz,
    //     Silica,
    //     Stone,
    //     Gravel,
    //     Concrete,
    //     OilContainer,
    //     GasContainer
    // }
    public int quantity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
