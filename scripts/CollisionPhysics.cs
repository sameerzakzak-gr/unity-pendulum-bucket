using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPhysics : MonoBehaviour
{
    public GameObject bucket;
    public GameObject sphere;
    public GameObject sphere1;
    public GameObject window;
    public GameObject paint;

    public float sphereMass = 3;
    public float sphere1Mass = 5;
    public float sphereRadius;
    public float sphere1Radius;
    public float vs = 4;
    public float vs1 = -6;
    Vector3 sphereCurrentVelocity,spherePreviousVelocity;
    Vector3 sphere1CurrentVelocity, sphere1PreviousVelocity;
    Vector3 sphereNewVelocity;
    Vector3 sphere1NewVelocity;
    Vector3 windowVelocity = Vector3.zero;
    float e=0.85f;
    GameObject target;
    GameObject target2;
    private void Start()
    {
        sphereCurrentVelocity.y = vs;
        sphere1CurrentVelocity.y = vs1;
        spherePreviousVelocity = sphereCurrentVelocity;
        sphere1PreviousVelocity = sphere1CurrentVelocity;

        target = GameObject.FindWithTag("window");
        
    }

    private void Update()
    {

        spherePreviousVelocity = sphereCurrentVelocity;
        sphere1PreviousVelocity = sphere1CurrentVelocity;
        //sphere1CurrentVelocity = bucket.GetComponent<Pendulum>().currentVelocity


        //SphereDetection();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bucket"))
        {
            sphereCollisionResponse();
            //Debug.Log(transform.position);
            //Debug.Log(sphereCurrentVelocity);
           // Debug.Log(sphere1CurrentVelocity);
           //Update();
        }
            
        if (other.CompareTag("window"))
        {
            Instantiate(paint, transform.position, Quaternion.identity);
            Destroy(sphere);
        }
        
    }
    public void SphereDetection()
    {
        Vector3 distance = sphere.transform.position - sphere1.transform.position;
        float length = Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y + distance.z * distance.z);
        float sumRadius = sphereRadius + sphere1Radius;

        if (length <= sumRadius)
        {
            //sphereCollisionResponse();

        }
    }

    public void sphereCollisionResponseWithGround()
    {
        //if(sphere.transform.position.y == window.transform.position.y)
        //{
           
        //    sphereCurrentVelocity = windowVelocity / e;
        //    sphereCurrentVelocity = Vector3.zero;
        //}
    
    }
    public void sphereCollisionResponseWithBucket()
    {
        if (sphere.transform.position.x <= (bucket.transform.position.x - 2) || sphere.transform.position.x >= (bucket.transform.position.x + 2) ||
            sphere.transform.position.y <= (bucket.transform.position.y - 5) || sphere.transform.position.y >= (bucket.transform.position.y + 5) ||
            sphere.transform.position.z <= (bucket.transform.position.z - 2) || sphere.transform.position.z >= (bucket.transform.position.z + 2))
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                sphereNewVelocity = sphereCurrentVelocity / e;

            }
        }
    }
    public void sphereCollisionResponse()
    {
        sphereCurrentVelocity = ((2*sphere1Mass*sphere1PreviousVelocity)+((sphereMass-sphere1Mass)*spherePreviousVelocity))/(sphereMass+sphere1Mass);
        sphere1CurrentVelocity = ((2 * sphereMass * spherePreviousVelocity) - ((sphereMass - sphere1Mass) * sphere1PreviousVelocity)) / (sphereMass + sphere1Mass);
        Debug.Log(sphereCurrentVelocity);
        Debug.Log(spherePreviousVelocity);
        Debug.Log(sphereMass);
        Debug.Log(sphere1Mass);
        Debug.Log(sphere1CurrentVelocity);
        Debug.Log(sphere1PreviousVelocity);
        Debug.Log(sphere1Mass);
    }
}
