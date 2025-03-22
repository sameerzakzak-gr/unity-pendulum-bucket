using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Physicss : MonoBehaviour
{
    ////[SerializeField]
    ////GameObject gameObject;

    //[SerializeField]
    //float θmax, l, m;
    //const float c = 0.82f, c1 = 0.42f;
    //float t, fTotal, w, a, θ, w0, φ=1, x, ρ;
    //float t0, fair, s;
    //Vector3 v;

    //[SerializeField] float timer = 0f;
    //float speed;
    //int phase = 0;

    //void FixedUpdate()
    //{
    //    //transform.Rotate(0f, speed * timer / 2, 0f);
    //    t0 = Time.fixedDeltaTime;

    //    timer += Time.fixedDeltaTime;
    //    if (timer > 1f)
    //    {
    //        phase++;
    //        phase %= 4;
    //        timer = 0f;
    //    }

    //    switch(phase)
    //    {
    //        case 0:
    //            speed = X0() - Fair();
    //            transform.Rotate(0f, 0f, speed * (1 - timer));
    //            break;

    //        case 1:
    //            speed = X0() - Fair();
    //            transform.Rotate(0f, 0f, -speed * timer);
    //            break;

    //        case 2:
    //            speed = X0() - Fair();
    //            transform.Rotate(0f, 0f, -speed * (1 - timer));
    //            break;

    //        case 3:
    //            speed = X0() - Fair();
    //            transform.Rotate(0f, 0f, speed * timer);
    //            break;

    //    }

    //}

    //// F drag = C drag* ρ air* A*v2

    //float V()
    //{
    //    return l * l * l / 4;
    //}
    //float Pro()
    //{
    //    ρ = m / V();
    //    return ρ;
    //}
    //float Area()
    //{
    //    s = l * (l/ 2);
    //    return s;
    //}

    //float Fair()
    //{
    //    fair = 0.5f * 0.82f * ρ * Area() * (X() * X());
    //    return fair;
    //}

    //float W0()
    //{
    //    w0 = Mathf.Sqrt(9.8f / l);
    //    return w0;
    //}

    //float X()
    //{
    //    θmax-=5;
    //    Debug.Log(θmax);
    //    return θmax;
    //}
    //float θtotal()
    //{
    //    θ = θmax * Mathf.Cos(W0() * t0 + φ);

    //    return θ;
    //}

    //float A()
    //{
    //    a = (-((W() * Mathf.Cos(θtotal()))) + T()) / m;
    //    return a;
    //}

    //float X0()
    //{
    //    x = A() * t0;
    //    return x;
    //}

    //float W()
    //{
    //    w = -m * 9.8f *Mathf.Sin(θ);
    //    return w;
    //}


    //float T()
    //{
    //    if (θtotal() <= 0.24f)
    //    {
    //        float value;
    //        value = l / 9.8f;
    //        t = 2 * Mathf.PI * Mathf.Sqrt(value);
    //    }
    //    else
    //    {
    //        float value;
    //        value = l / 9.8f;
    //        t = 2 * Mathf.PI * Mathf.Sqrt(value);
    //        t = t * (1 + θtotal() / 16);
    //    }

    //    return t;
    //}
    int x;

    void Start()
    {
        x = 1;
    }
    void Update()
    {
        StartCoroutine(Stop());
    }
    IEnumerator Stop()
    {
        transform.Rotate(0, x, 0);
        yield return new WaitForSeconds(30);
        x = 0;
    }
    
}




