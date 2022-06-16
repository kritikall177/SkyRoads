using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public Plane Road;

    private List<Plane> roads = new List<Plane>();

    public float startSpeed = 100;
    
    public int maxRoadCount = 5;

    public float positionToOffset = -15; // position on z 

    private float _speed = 0;

    private float _roadOffset;
    
    private void Start()
    {
        _roadOffset = Road.meshFilter.sharedMesh.bounds.size.z;
        StartLevel();
    }
    
    private void Update()
    {
        RoadMovement();
    }

    private void RoadMovement()
    {
        foreach (var road in roads)
        {
            road.planeGameObject.transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if (roads[0].planeGameObject.transform.position.z < positionToOffset)
        {
            ResetPosition();
        }
    }
    
    private void ResetPosition()
    {
        var road = roads[0];
        roads.RemoveAt(0);
        road.asteroidGenerator.SpawnAsteroid();
        road.planeGameObject.transform.position = roads[roads.Count - 1].planeGameObject.transform.position + new Vector3(0,0, _roadOffset);
        roads.Add(road);
    }
    
    private void CreateNextRoad()
    {
        var pos = Vector3.zero;
        if (roads.Count > 0)
        {
            pos = roads[roads.Count - 1].transform.position +
                  new Vector3(0, 0, _roadOffset); //z смешение на ширину плоскости
        }

        var road = Instantiate(Road, pos, Quaternion.identity);
        road.transform.SetParent(transform);
        roads.Add(road);
    }

    public void StartLevel()
    {
        for (var i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
        
        _speed = startSpeed;
    }
    
    public void ResetLevel()
    {
        _speed = 0;
        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }

        for (var i = 0; i < maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }
}
