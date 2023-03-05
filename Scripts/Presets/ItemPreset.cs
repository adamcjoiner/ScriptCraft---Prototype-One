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

[CreateAssetMenu(fileName = "Item Preset", menuName = "New Item Type")]
public class ItemPreset : ScriptableObject
{
    public string displayName;
    public string description;
    public GameObject prefab;

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
