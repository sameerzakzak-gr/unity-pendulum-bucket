using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOther : MonoBehaviour
{
    public Transform Pivot;
    // Update is called once per frame
    void Update()
    {
        Vector3 d = Pivot.position - transform.position;
        Quaternion r = Quaternion.LookRotation(d);
        transform.rotation = r;
    }

    void lookAt()
    {
        var delta = Pivot.transform.position - transform.position;
        delta.z = 0;
        var rotation = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
    }
}
