using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject path;
    public GameObject diamond;
    
    
     public void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            PathGeneration();
            
        }
    }

    public void PathGeneration()//yol oluşturma
    {
        Vector3 pathdirection;
        if (Random.Range(0,2)==0)
        {
            pathdirection = Vector3.left;
            diamond = Instantiate(diamond, path.transform.position + new Vector3(0, 0.7f, 0), diamond.transform.rotation);
        }
        else
        {
            pathdirection = Vector3.forward;
        }
        path = Instantiate(path, path.transform.position + pathdirection, path.transform.rotation,transform.parent);
    }

    

   

}
