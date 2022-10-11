using UnityEngine;
using TMPro;
using System;

public class TextField : MonoBehaviour
{
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;

    private TMP_InputField _inputField;
    private float _currentValue;

    public Action<float> OnValueChange;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
    }

    private void GetFieldValue() 
    {
        string text = _inputField.text;

        if (float.TryParse(text, out float value)) 
        {
            value = value < _minValue ? _minValue : value;
            value = value > _maxValue ? _maxValue : value;

            _currentValue = value;
        }

        SetText(_currentValue.ToString());
    }

    private void SetText(string text) 
    {
        _inputField.text = text;
    }

    public void ValueChange() 
    {
        GetFieldValue();

        OnValueChange?.Invoke(_currentValue);
    }
}