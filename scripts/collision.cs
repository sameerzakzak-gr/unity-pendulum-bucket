using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    bool iscollided=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other)
     {
         if(other.CompareTag("drop"))
         {   StartCoroutine(impact(other.gameObject));
             iscollided=true;
         }
     }
    
     IEnumerator impact(GameObject gameObject)
    {   this.transform.position+=new Vector3(10,10,10);
        gameObject.transform.position-=Vector3.one;
        yield return new WaitForSeconds(5);
        
    }
}