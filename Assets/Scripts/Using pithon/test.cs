using UnityEditor;
using UnityEditor.Scripting.Python;
using UnityEngine;

public class MenuItem_test_Class
{
   [MenuItem("Python Scripts/test")]
   public static void test()
   {
       PythonRunner.RunFile("Assets/Scripts/Using pithon/test.py");
    }
};
