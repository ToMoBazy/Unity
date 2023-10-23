using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class zadanie_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    private bool Forward = true;
    void Start()
    {
       transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Forward)
        {
            if(transform.position.x > -10f)
            {
                transform.position += new Vector3(-10f * Time.deltaTime * speed,0,0);
            }
            else
            {
                Forward = false;
            }
        }
        else
        {
            if(transform.position.x < 0f)
            {
                transform.position += new Vector3(10f * Time.deltaTime * speed,0,0);
            }
            else
            {
                Forward = true;
            }

            
        }
        

       
         
        
        

         
    }
}
