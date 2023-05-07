using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    public int _startHealth;
    public int _health;
    public void SetProperty(int prop)
    {
        _health -= prop;
        float damage = _health / (float)_startHealth;
        Debug.Log(damage);
        _transform.localScale = new Vector3(damage, 1, 1);
    }
}
