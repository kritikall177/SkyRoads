using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Plane _road;
    [SerializeField] private float _startSpeed = 30f;
    [SerializeField] private int _maxRoadCount = 15;
    [SerializeField] private float _positionToOffset = -15f; // position on z 
    [SerializeField] private float _speedAcceleration = 1f;
    
    
    private float _currentSpeed;
    private float _roadOffset;
    private readonly List<Plane> _roads = new List<Plane>();
    
    private void Start()
    {
        _roadOffset = _road.meshFilter.sharedMesh.bounds.size.z;
        StartLevel();
        StartCoroutine(SpeedBoost());
    }
    
    private void Update()
    {
        RoadMovement();
    }

    private void FixedUpdate()
    {
        NitroAcceleration();
    }

    private void RoadMovement()
    {
        foreach (var road in _roads)
        {
            road.planeGameObject.transform.position -= new Vector3(0, 0, _currentSpeed * Time.deltaTime);
        }

        if (_roads[0].planeGameObject.transform.position.z < _positionToOffset)
        {
            ResetPosition();
        }
    }
    
    private void ResetPosition()
    {
        var road = _roads[0];
        _roads.RemoveAt(0);
        road.asteroidGenerator.SpawnAsteroid();
        road.planeGameObject.transform.position = _roads[_roads.Count - 1].planeGameObject.transform.position + new Vector3(0,0, _roadOffset);
        _roads.Add(road);
    }
    
    private void CreateNextRoad()
    {
        var pos = Vector3.zero;
        if (_roads.Count > 0)
        {
            pos = _roads[_roads.Count - 1].transform.position +
                  new Vector3(0, 0, _roadOffset); //z смешение на ширину плоскости
        }

        var road = Instantiate(_road, pos, Quaternion.identity);
        road.transform.SetParent(transform);
        _roads.Add(road);
    }

    public void StartLevel()
    {
        for (var i = 0; i < _maxRoadCount; i++)
        {
            CreateNextRoad();
        }
        
        _currentSpeed = _startSpeed;
    }
    
    public void ResetLevel()
    {
        _currentSpeed = 0;
        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }

        for (var i = 0; i < _maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

    private IEnumerator SpeedBoost()
    {
        yield return new WaitForSeconds(1);
        _currentSpeed += _speedAcceleration;
        StartCoroutine(SpeedBoost());
    }

    public void NitroAcceleration()
    {
        if (Input.GetKey(KeyCode.X))
        {
            _currentSpeed = 60f;
        }
        else
        {
            _currentSpeed = 30f;
        }
    }
}
