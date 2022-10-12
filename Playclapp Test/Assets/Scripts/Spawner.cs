using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxSize;

    private float _lastSpawnTime;
    private Vector3 _spawnPosition;

    private ObjectPool<Cube> _pool;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool() 
    {
        _spawnPosition = transform.position;

        _pool = new ObjectPool<Cube>(() =>
        {
            return Instantiate(_cubePrefab);
        }, cube =>
        {
            cube.gameObject.SetActive(true);
            cube.Init(cube => _pool.Release(cube), _spawnPosition);
        }, cube => {
            cube.gameObject.SetActive(false);
        }, cube => {
            Destroy(cube.gameObject);
        }, true, _poolDefaultCapacity, _poolMaxSize);
    }

    private void Update()
    {
        if (Time.time > _lastSpawnTime + GlobalSettings.SpawnDelay) SpawnCube();
    }

    private void SpawnCube() 
    {
        _lastSpawnTime = Time.time;

        _pool.Get();
    }
}