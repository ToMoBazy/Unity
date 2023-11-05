using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random=UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;
    List<Vector3> positions = new List<Vector3>();
    public Material[] randomMaterials;
    public float delay = 3.0f;
    public int number_objectt = 5;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
               
        m_Collider = GetComponent<Collider>();
       
        m_Center = m_Collider.bounds.center;
        
        m_Size = m_Collider.bounds.size;
      
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
    
        OutputData();
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)m_Min.x, (int)m_Max.x).OrderBy(x => Guid.NewGuid()).Take(number_objectt));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)m_Min.z, (int)m_Max.z).OrderBy(x => Guid.NewGuid()).Take(number_objectt));
        
        for(int i=0; i<number_objectt; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], m_Max.y, pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            GameObject obj = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            int color = Random.Range(0, randomMaterials.Length);
            obj.GetComponent<MeshRenderer>().material = randomMaterials[color];
            yield return new WaitForSeconds(this.delay);
            
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
        void OutputData()
    {
      
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }
}