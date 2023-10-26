using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float acceleration;
    public float rotationspeed;
    public float maxspeed;
    public Text txtSpeed;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AddSpeed();
        AddRotation();
        AdjustVelocity();

        txtSpeed.text = $"Speed: {rigid.velocity.magnitude.ToString("0.##")} Km/h";
    }

    void AddSpeed()
    {
        if (rigid.velocity.magnitude >= maxspeed)
            return;
        float inputForward = Input.GetAxis("Vertical");
        rigid.AddForce(transform.forward * acceleration * inputForward);
    }

    void AddRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0,rotation * rotationspeed,0));
    }

    void AdjustVelocity()
    {
        Vector3 velocity = rigid.velocity;

        float direction = Vector3.Dot(transform.forward, velocity.normalized);

        //vorwärts
        if (direction > 0)
            velocity = transform.forward * velocity.magnitude;

        //rückwärts
        if(direction < 0)
            velocity = -transform.forward * velocity.magnitude;

        rigid.velocity = velocity;
    }
}
