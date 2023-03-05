using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceNode : MonoBehaviour
{
    public enum ResourceType {Stone, Iron, Copper, Bauxite, Quartz, Wood, Foliage};
    public ResourceType resourceType;
    public int startQuantity = 12;
    public int quantity;
    
    private bool harvested = false;


    // Update startQunitity when new resourceType is selected
    // void OnInspectorGUI()
    // {
    //     ResourceType type = resourceType as resourceNode;
    //     resourceType newValue = (resourceType)EditorGUILayout.EnumPopup( type.myEnumVal );
    //     if( newValue != type.myEnumVal)
    //     {
    //         type.myEnumVal = newValue;

    //         switch (type)
    //         {
    //             case resourceNode.resourceType.Stone:
    //                 startQuantity = 12;
    //                 break;
    //             case resourceNode.resourceType.Iron:
    //                 startQuantity = 8;
    //                 break;
    //             default:
    //                 break;
    //         }
            
    //         // do stuff, call functions, etc.
    //     }
    // }

    private void Start() {
        if (harvested == false)
        {
            quantity = startQuantity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
