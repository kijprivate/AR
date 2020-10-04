using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGuiTesting : MonoBehaviour
{
    #region Singleton
    private static OnGuiTesting instance;
    public static OnGuiTesting Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return FindObjectOfType<OnGuiTesting>();
        }
    }
    #endregion

    public string message1;
    public string message2;

    private void Awake()
    {
        instance = this;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(30, 30, 1000, 1000), message1);
        GUI.Label(new Rect(30, 80, 1000, 1000), message2);
    }
}
