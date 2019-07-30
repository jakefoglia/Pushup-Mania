using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float vertSpeed = 8;
    [SerializeField] private float rotSpeed = 105;

    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Horizontal");

        Vector3 newPos = transform.position + (new Vector3(0, vert)) * vertSpeed * Time.deltaTime;
        float newRotZ = transform.eulerAngles.z + rot * rotSpeed * Time.deltaTime * -1;

        if (newPos.y > 2.5f)
        {
            newPos.y = 2.5f;
        }
        else if (newPos.y < -1)
        {
            newPos.y = -1;
        }
        newPos.x = 0;
        newPos.z = 0;
        transform.position = newPos;

        if (newRotZ > 45 && newRotZ < 180)
        {
            newRotZ = 45;
        }
        else if (newRotZ < 315 && newRotZ > 180)
        {
            newRotZ = 315;
        }

        GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        transform.rotation = Quaternion.Euler(0, 0, newRotZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(LoadMenu(1));   
    }

    IEnumerator LoadMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);
    }
}