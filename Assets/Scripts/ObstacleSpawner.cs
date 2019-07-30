using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject centerBar; 
    [SerializeField] private GameObject horizontalBar;
    [SerializeField]  private GameObject leftBar;
    [SerializeField]  private GameObject rightBar;

    [SerializeField] private float respawnTime = 2.4f;
    [SerializeField] private float obstacleSpeed = 10;
    [SerializeField] private float startDistance = 15;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
        
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            int i = UnityEngine.Random.Range(0, 3);

            GameObject obj;

            if (i == 0)         //horizontal
            {
                obj = Instantiate(horizontalBar) as GameObject;
                obj.transform.localScale = new Vector3(5, 3, 1);
                obj.transform.localPosition = new Vector3(0, 2.5f, startDistance);
                
            }
            else if (i == 1)    //left
            {
                obj = Instantiate(leftBar) as GameObject;
                obj.transform.localScale = new Vector3(1.5f, 6, 1);
                obj.transform.localPosition = new Vector3(-1.5f, 1, startDistance);
                obj.transform.localEulerAngles = new Vector3(0, 0, 45);
            }
            else                //right
            {
                obj = Instantiate(rightBar) as GameObject;
                obj.transform.localScale = new Vector3(1.5f, 6, 1);
                obj.transform.localPosition = new Vector3(1.5f, 1, startDistance);
                obj.transform.localEulerAngles = new Vector3(0, 0, 315);
            }
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * obstacleSpeed);


            yield return new WaitForSeconds(respawnTime);

            // center
            obj = Instantiate(centerBar) as GameObject;
            obj.transform.localScale = new Vector3(4, 4, 1);
            obj.transform.localPosition = new Vector3(0, -1, startDistance);

            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * obstacleSpeed);

        }
    }
}