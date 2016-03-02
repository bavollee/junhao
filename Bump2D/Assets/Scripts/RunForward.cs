using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class RunForward : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool isRun = false;

    private Rigidbody2D _rigid2d;


    void Start()
    {
        _rigid2d = GetComponent<Rigidbody2D>();
    }

    public void Run()
    {
        _rigid2d.AddForce(transform.TransformDirection(Vector3.right) * _rigid2d.mass * _rigid2d.drag * moveSpeed);
    }
}
