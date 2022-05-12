using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float mSpeed;  

    public float speed = 12f;
    public Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
        mSpeed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody fireBullet;
            fireBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            fireBullet.AddForce(transform.forward * 1000);
        }
    }
    
}
