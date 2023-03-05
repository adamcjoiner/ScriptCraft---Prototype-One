using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/***
*
* Defines machines that can be constructed to harvest/refine resources, fabricate components, assemble units, etc.
*
*/

[CreateAssetMenu(fileName = "Machine Preset", menuName = "New Machine Type")]
public class MachinePreset : ScriptableObject
{
    public string displayName;
    public string description;
    public GameObject prefab;
    public int cost; // construction cost
    public int consumption; // amount of power used per minute
    
    [Range(1f, 30f)]
    [SerializeField] public int range;

    // Types to create from this definition:
        // PowerPlant // generates wireless power (in a limited radius) when placed on oil or gas
        // WirelessPowerBeacon,
        // Platform,
        // ThreeDPrinter,
        // Refiner,
        // ChemistryChamber,
        // Fabricator,
        // AssemblyChamber,
        // ConveyorBelt,
        // FoundationBlock,
        // Wall,
        // Ceiling,
        // Door,
        // Window

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
