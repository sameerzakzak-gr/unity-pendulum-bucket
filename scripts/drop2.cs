using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop2 : MonoBehaviour
{   public float holelocationx,holelocationz;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        StartCoroutine(dropball());
    }
   
    IEnumerator dropball()
    {
        
        yield return new WaitForSeconds(2);
        Instantiate(ball,transform.position+new Vector3(holelocationx,0,holelocationz),Quaternion.identity);
    }

    public void SetActiveTrue(){
        ball.SetActive(true);
    }
public void SetActiveFalse(){
        ball.SetActive(false);
    }
}
