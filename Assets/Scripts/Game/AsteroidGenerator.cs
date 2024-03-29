using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _asteroid;
    [SerializeField] private GameObject _addScoreTrigger;
    
    [SerializeField] private Vector3 _centralPosition = new Vector3(0f, 1.3f, -5f);
    [SerializeField] private Vector3 _leftPosition = new Vector3(-3.5f, 1.3f, -5f);
    [SerializeField] private Vector3 _rightPosition = new Vector3(3.5f, 1.3f, -5f);
    
    private static int SpawnChance = 100;

    private Vector3[] _positions = new Vector3[3];

    private void Start()
    {
        _positions[0] = _centralPosition;
        _positions[1] = _leftPosition;
        _positions[2] = _rightPosition;
    }

    public void SpawnAsteroid()
    {
        if (Random.Range(0, 101) <= SpawnChance)
        {
            _asteroid.SetActive(true);
            _addScoreTrigger.SetActive(true);
            _asteroid.transform.localPosition = _positions[Random.Range(0, 3)];
        }
        else
        {
            _asteroid.SetActive(false);
            _addScoreTrigger.SetActive(false);
        }
    }

    public static void SetSpawnChance(float value)
    {
        SpawnChance = (int)Mathf.Lerp(0, 100, value);
    }
    
    public static float GetSpawnChance()
    {
        return (float) SpawnChance / 100;
    }
}
