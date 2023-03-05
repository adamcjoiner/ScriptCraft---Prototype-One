using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 *  Syntax for comments:
 *  * Important information to highlight
 *  ! Warning messages
 *  ? Unanswered questions: Does this class really need to be a singleton?
 *  TODO Pending tasks to complete
 */

public class ScriptcraftControls : EditorWindow
{
[MenuItem("Window / ScriptCraft Controls")]

public static void ShowWindow()
{
    EditorWindow.GetWindow(typeof(ScriptcraftControls));
}

    void OnGUI()
    {
        
    }
}
