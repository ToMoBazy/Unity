using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_5 : MonoBehaviour
{
  
   private int[] array1 = new int[10];
   private int[] array2 = new int[10];
   public GameObject block;
   public int width = 10;
   public int height = 4;
  
   void Start()
   {
        System.Random random = new System.Random();

        for (int i = 0; i < 10; i++)
        {
            array1[i] = random.Next(-10, 10); 
            array2[i] = random.Next(-10, 10);
        }
       

        for (int x=0; x<10; x++)
        {
            Instantiate(block, new Vector3(array1[x],1,array2[x]), Quaternion.identity);
        }
             
   }

}
