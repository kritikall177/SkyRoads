using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Plane _road;
    [SerializeField] private float _startSpeed = 30f;
    [SerializeField] private int _maxRoadCount = 15;
    [SerializeField] private float _positionToOffset = -15f; // position on z 
    [SerializeField] private float _defaultAccelerationSpeed = 1f;
    [SerializeField] private float _maxSpeed = 100f;

    public float _currentSpeed;
    private float _defaultSpeed;
    private float _roadOffset;
    private readonly List<Plane> _roads = new List<Plane>();

    private void Start()
    {
        GameEventManager.LoseGame += StopLevel;
        GameEventManager.RestartGame += ResetLevel;
        GameEventManager.StartGame += ResetLevel;
        LerpAccelerationSystem.LerpAction += ChangeCurrentSpeed;
        _roadOffset = _road.meshFilter.sharedMesh.bounds.size.z;
        StartLevel();
    }

    private void FixedUpdate()
    {
        RoadMovement();
    }

    private void RoadMovement()
    {
        foreach (var road in _roads)
        {
            road.planeGameObject.transform.Translate(new Vector3(0, 0, -_currentSpeed * Time.deltaTime));
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
                  new Vector3(0, 0, _roadOffset); // z смешение на ширину плоскости
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
        
        _defaultSpeed = _startSpeed;
        _currentSpeed = _defaultSpeed;
       StopAllCoroutines();
    }
    
    public void ResetLevel()
    {
        while (_roads.Count > 0)
        {
            var road = _roads[_roads.Count - 1];
            _roads.RemoveAt(_roads.Count - 1);
            Destroy(road.planeGameObject);
        }
        
        StartLevel();
        enabled = true;
    }

    public void StopLevel()
    {
        _defaultSpeed = 0;
        StopCoroutine(SpeedBoost());
        enabled = false;
    }

    private IEnumerator SpeedBoost()
    {
        yield return new WaitForSeconds(1);
        if (_defaultSpeed < _maxSpeed)
        {
            _defaultSpeed += _defaultAccelerationSpeed;
            StartCoroutine(SpeedBoost());
        }
    }

    private void ChangeCurrentSpeed(bool isPressed, float percentageOfLerp)
    {
        if (isPressed)
        {
            _currentSpeed = Mathf.Lerp(_defaultSpeed, _defaultSpeed * 2, percentageOfLerp);
        }
        else
        {
            _currentSpeed = Mathf.Lerp(_defaultSpeed * 2, _defaultSpeed, percentageOfLerp);
        }
    }
}
