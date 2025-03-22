using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rope_length : MonoBehaviour
{
   public Slider slider;
   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Length(float length)
    {
      this.GetComponent<Pendulum>().ropeLength=length;

    }
    public void mass(float mass){
            this.GetComponent<Pendulum>().mass=mass;
    }
}
