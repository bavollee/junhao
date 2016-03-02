using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoRot : MonoBehaviour
{
    public float speed = 50f;

    private Transform _tran;
    private Rigidbody2D _rb2d;
    private bool _isRotCW = true;


    void Start()
    {
        _tran = transform;
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float flag = _isRotCW ? 1 : -1;
        _rb2d.MoveRotation(_rb2d.rotation + flag * speed * Time.deltaTime);
    }


    public void ReverseRot()
    {
        _isRotCW = !_isRotCW;
    }
}
