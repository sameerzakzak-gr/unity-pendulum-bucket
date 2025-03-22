using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour
{
    public GameObject paint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            
        if (other.CompareTag("window"))
        {
            Instantiate(paint, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}