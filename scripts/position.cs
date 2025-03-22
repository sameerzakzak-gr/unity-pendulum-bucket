using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class position : MonoBehaviour
{
    public Slider slider;


    // Update is called once per frame
    void Update()
    {

    }
    public void bucket_positionX(float value)
    {
        this.transform.position = new Vector3( value, 0, 0);

    }
    public void bucket_positionY(float value)
    {
        this.transform.position = new Vector3(0, value, 0);

    }
    public void bucket_positionZ(float value)
    {
        this.transform.position = new Vector3(0, 0, value);

    }
}
