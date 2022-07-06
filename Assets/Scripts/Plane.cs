using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject planeGameObject;
    public MeshFilter meshFilter;
    public AsteroidGenerator asteroidGenerator;

    private void Start()
    {
        planeGameObject = gameObject;
    }
}
