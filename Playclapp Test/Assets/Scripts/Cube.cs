using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    private Vector3 _diraction = Vector3.forward;

    private Action<Cube> OnDistanceComplite;

    public void Init(Action<Cube> OnComplite, Vector3 startPosition)
    {
        OnDistanceComplite = OnComplite;
        transform.position = startPosition;
    }

    private void Update()
    {
        if (transform.position.z < GlobalSettings.Distance)
            Move();
        else
            OnDistanceComplite?.Invoke(this);
    }

    private void Move()
    {
        transform.Translate(GlobalSettings.CubeSpeed * Time.deltaTime * _diraction);
    }
}