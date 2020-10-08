using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class RouteManager : MonoBehaviour
{
    [SerializeField] private AbstractMap map;
    [SerializeField] private Route route;

    [SerializeField] private GameObject pointPrefab; // TODO specific for point?

    List<GameObject> spawnedObjects;
    Vector2d[] locations;

    #region Singleton
    private static RouteManager instance;
    public static RouteManager Instance
    {
        get
        {
            if (instance == null)
            {
                return FindObjectOfType<RouteManager>();
            }
            return instance;
        }
    }
    #endregion

    private void Start()
    {
        locations = new Vector2d[route.routePoints.Count];
        spawnedObjects = new List<GameObject>();
        for (int i = 0; i < route.routePoints.Count; i++)
        {
            locations[i] = Conversions.StringToLatLon(route.routePoints[i].locationString);
            var obj = Instantiate(pointPrefab);
            obj.transform.localPosition = map.GeoToWorldPosition(locations[i], true);
            spawnedObjects.Add(obj);
        }
    }

    private void Update()
    {
        int count = spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {
            var spawnedObject = spawnedObjects[i];
            var location = locations[i];
            spawnedObject.transform.localPosition = map.GeoToWorldPosition(location, true);
        }
    }
}
