using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    [SerializeField] private TextField _distanceField;
    [SerializeField] private TextField _spawnDelayField;
    [SerializeField] private TextField _cubeSpeedField;

    private float _distance;
    private float _spawnDelay;
    private float _cubeSpeed;

    private float _lastSpawnTime;

    private void Start()
    {
        _distanceField.OnValueChange += (float x) => _distance = x;
        _spawnDelayField.OnValueChange += (float x) => _spawnDelay = x;
        _cubeSpeedField.OnValueChange += (float x) => _cubeSpeed = x;

        _distanceField.ValueChange();
        _spawnDelayField.ValueChange();
        _cubeSpeedField.ValueChange();
    }

    private void Update()
    {
        if (Time.time > _lastSpawnTime + _spawnDelay) 
            InstantiateCube();
    }

    private void InstantiateCube() 
    {
        _lastSpawnTime = Time.time;

        Cube cube = Instantiate(_cubePrefab, transform);
        cube.Speed = _cubeSpeed;
        cube.SetTargetPosition(_distance);
        cube.StartMove();
    }
}