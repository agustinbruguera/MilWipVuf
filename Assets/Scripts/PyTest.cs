using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class PyTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PythonRunner.RunFile("Assets/Scripts/Using pithon/test.py");
    }
}
