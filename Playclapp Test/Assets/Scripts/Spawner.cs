using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _distance;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _cubeSpeed;

    private float _lastSpawnTime;

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