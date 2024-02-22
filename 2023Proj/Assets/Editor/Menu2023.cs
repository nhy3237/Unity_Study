using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.SceneManagement;

public class Menu2023 : MonoBehaviour
{
    [MenuItem("Menu2023/Clear PlayerPrefs")]
    private static void Clear_PlayerPrefsAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clear_PlayerPrefsAll");
    }

    [MenuItem("Menu2023/Submenu/Select")]
    private static void subMenu_Select()
    {
        Debug.Log("Sub Menu 1 - Select");
    }

    /*
    % - Ctrl
    # - Shift
    & - Alt
    */

    [MenuItem("Menu2023/Submenu/HotKey Test1 %#[")]
    private static void subMenu_Hotkey_1()
    {
        Debug.Log("Hotkey Test : Ctrl + Shift + [");
    }

    [MenuItem("Assets/Load Selected Scene")]
    private static void LoadSelectedScene()
    {
        var selected = Selection.activeObject;

        if (EditorApplication.isPlaying)
            EditorSceneManager.LoadScene(AssetDatabase.GetAssetPath(selected));
        else
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected));
    }
}
