using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/***
*
* Defines robotic components that can be fabricated from raw materials (refined from mined resources)
*
*/

[CreateAssetMenu(fileName = "Component Preset", menuName = "New Component Type")]
public class ComponentPreset : ScriptableObject
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
