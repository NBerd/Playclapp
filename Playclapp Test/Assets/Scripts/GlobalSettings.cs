using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    [SerializeField] private TextField _distanceField;
    [SerializeField] private TextField _spawnDelayField;
    [SerializeField] private TextField _cubeSpeedField;

    public static float Distance { get; private set; }
    public static float SpawnDelay { get; private set; }
    public static float CubeSpeed { get; private set; }

    private void Start()
    {
        _distanceField.OnValueChange += value => Distance = value;
        _spawnDelayField.OnValueChange += value => SpawnDelay = value;
        _cubeSpeedField.OnValueChange += value => CubeSpeed = value;

        _distanceField.ValueChange();
        _spawnDelayField.ValueChange();
        _cubeSpeedField.ValueChange();
    }
}