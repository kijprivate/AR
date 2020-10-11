using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.MeshGeneration.Factories;

public class RouteManager : MonoBehaviour
{
    [SerializeField] private AbstractMap map;
    [SerializeField] private DirectionsFactory directionsFactory;
    [SerializeField] private Route route;

    [SerializeField] private GameObject pointPrefab; // TODO specific for point?

    private Route.RoutePoint currentPoint;
    public Route.RoutePoint CurrentPoint
    {
        get => currentPoint;
    }

    int currentPointIndex;
    
    List<GameObject> spawnedObjects = new List<GameObject>();
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

    public void StartRoute()
    {
        CreatePoints();
        AddNavigation();
    }

    public void SetNextPoint()
    {
        currentPointIndex++;
        currentPoint = route.routePoints[currentPointIndex];
        directionsFactory.waypoints[1] = route.routePoints[currentPointIndex].gObject.transform;
    }

    private void AddNavigation()
    {
        currentPointIndex = 0;
        currentPoint = route.routePoints[currentPointIndex];
        //first waypoint in factory is always player and second is our destination
        directionsFactory.waypoints[1] = route.routePoints[currentPointIndex].gObject.transform;
    }

    private void CreatePoints()
    {
        foreach (var obj in spawnedObjects)
            Destroy(obj);

        locations = new Vector2d[route.routePoints.Count];
        spawnedObjects = new List<GameObject>();
        for (int i = 0; i < route.routePoints.Count; i++)
        {
            locations[i] = Conversions.StringToLatLon(route.routePoints[i].locationString);
            var obj = Instantiate(pointPrefab);
            obj.transform.localPosition = map.GeoToWorldPosition(locations[i], true);
            route.routePoints[i].gObject = obj;
            var data = obj.GetComponent<RoutePointData>();
            data.infoText = route.routePoints[i].infoText;
            spawnedObjects.Add(obj);
        }
    }
}
