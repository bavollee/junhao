using UnityEngine;
using System.Collections;

public class BumpJudge : MonoBehaviour
{
    public float power = 10f;


    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Rigidbody2D rigidCom = coll.gameObject.GetComponent<Rigidbody2D>();

            Vector2 force = coll.gameObject.transform.TransformDirection(coll.contacts[0].point);
            rigidCom.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
