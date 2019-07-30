using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject textHolder;

    // Update is called once per frame


    public int score;

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        textHolder.GetComponent<Text>().text = "SCORE: " + score;
    }
}
