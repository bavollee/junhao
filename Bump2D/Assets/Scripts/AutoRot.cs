using UnityEngine;
using System.Collections;

public class AutoRot : MonoBehaviour
{
    public float speed = 50f;

    private Transform _tran;
    private bool _isRotCW = true;


    void Start()
    {
        _tran = transform;
    }

    void Update()
    {
        Vector3 axis = _isRotCW ? Vector3.forward : Vector3.back;
        _tran.Rotate(axis, speed * Time.deltaTime);
    }


    public void ReverseRot()
    {
        _isRotCW = !_isRotCW;
    }
}
