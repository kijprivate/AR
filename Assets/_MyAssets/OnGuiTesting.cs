using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Examples;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class OnGuiTesting : MonoBehaviour
{
    #region Singleton
    private static OnGuiTesting instance;
    public static OnGuiTesting Instance
    {
        get
        {
            if (instance == null)
            {
                return FindObjectOfType<OnGuiTesting>();
            }
            return instance; 
        }
    }
    #endregion

    public string message1;
    public string message2;

    private void Awake()
    {
        instance = this;
    }

    private AbstractLocationProvider _locationProvider = null;
    void Start()
    {
        if (null == _locationProvider)
        {
            _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
        }
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(30, 30, 1000, 1000), message1);
        GUI.Label(new Rect(30, 80, 1000, 1000), message2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

        }
        if (Input.GetKeyDown(KeyCode.J))
        {

        }
        if (Input.GetKeyDown(KeyCode.U))
        {

        }
    }

    public void Lower()
    {
        var map = FindObjectOfType<AbstractMap>();
        map.SetZoom(16);
    }

    public void Higher()
    {
        var map = FindObjectOfType<AbstractMap>();
        map.SetZoom(19);
    }

    public void UpdateMap()
    {
        var map = FindObjectOfType<AbstractMap>();
        map.UpdateMap();
    }
}
