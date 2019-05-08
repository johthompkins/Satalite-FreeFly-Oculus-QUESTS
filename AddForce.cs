using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public int force;
    public ParticleSystem explode;
    public float time;
    public Transform target;
    public float speed;

    public void Start()
    {

        explode.Stop();
        time = Time.deltaTime;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(0,0,force);
        explode.Play();
    }
}
