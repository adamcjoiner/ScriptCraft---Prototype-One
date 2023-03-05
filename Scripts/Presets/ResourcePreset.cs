using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/***
*
* Defines the various resource nodes/deposits that can be found and mined around the map
*
*/

[CreateAssetMenu(fileName = "Resource Preset", menuName = "New Resource Type")]
public class ResourcePreset : ScriptableObject
{
    public string displayName;
    public string description;
    public GameObject prefab;

    // Don't need this. Create new types for each instead:
    // public enum type {
    //     Plant,
    //     Tree,
    //     BauxiteDeposit,
    //     CopperDeposit,
    //     QuartzDeposit,
    //     StoneDeposit,
    //     OilDeposit,
    //     GasDeposit
    // }

    public enum type {
        Combustable,
        Refineable,
        Combineable
    }
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
