#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public class ProgressCleaner : EditorWindow
{
    [MenuItem("ClearProgress/Clear")]
    static void Init()
    {
        PlayerPrefs.DeleteAll();
      
        Debug.Log("Progress Clear");
    }
}
#endif
