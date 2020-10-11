using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;

public class Route : MonoBehaviour //SO?
{
    public List<RoutePoint> routePoints = new List<RoutePoint>();

    [System.Serializable]
    public class RoutePoint
    {
        public string locationString;
        public string[] infoText; 
        public GameObject gObject;
    }
}
