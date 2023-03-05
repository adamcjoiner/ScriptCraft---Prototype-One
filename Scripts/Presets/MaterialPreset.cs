using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/***
*
* Defines material types that can be made by combining mined resources
*
*/

[CreateAssetMenu(fileName = "Material Preset", menuName = "New Material Type")]
public class MaterialPreset : ScriptableObject
{
    public string displayName;
    public string description;
    public GameObject prefab;
    public int health;
    public int consumption; // power consumption per minute
    public int powerCapacity; // battery capacity
    public int cost;

    // Don't need this. Create new types for each instead:
    // public enum type {
    //     UnitTypeOne,
    //     UnitTypeTwo
    // }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
