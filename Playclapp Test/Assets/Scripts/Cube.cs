using System;
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 _targetPosition;

    public float Speed { private get; set; }

    public void SetTargetPosition(float distance) 
    {
        Vector3 _currentPositon = transform.position;

        if (_currentPositon.z >= distance) 
            return;

        _targetPosition = _currentPositon; 
        _targetPosition.z = distance;
    }

    public void StartMove() 
    {
        StartCoroutine(MoveCoroutine(() => Destroy(gameObject)));
    }

    IEnumerator MoveCoroutine(Action OnComplite = null) 
    {
        while (transform.position != _targetPosition) 
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);

            yield return null;
        }

        OnComplite?.Invoke();
    }
}