﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hole : MonoBehaviour
{       public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void drip(float length)
    {
      this.GetComponent<Pendulum>().ropeLength=this.GetComponent<Pendulum>().ropeLength+length;

    }
}
