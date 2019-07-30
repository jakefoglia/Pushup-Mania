using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private GameObject scoreHolder;


    void Update()
    {
        
        if (transform.position.z < -15)
        {
            Destroy(gameObject);
            scoreHolder.GetComponent<Score>().score++;
        }
    }
}
