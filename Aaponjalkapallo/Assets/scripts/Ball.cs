using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int teamBlueScore = 0;
    public int teamRedScore = 0;
    Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.tag == "BlueGoal")
        {
            teamRedScore += 1;
        }
        if(other.tag == "RedGoal")
        {
            teamBlueScore += 1;
        }
        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
