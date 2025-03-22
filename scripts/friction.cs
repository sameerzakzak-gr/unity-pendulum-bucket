using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class friction : MonoBehaviour
{   
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void friction_change(float fric)
    {
        this.GetComponent<Pendulum>().freq_time=fric;
    }
}
