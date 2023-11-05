using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizehead : MonoBehaviour
{
    [SerializeField] GameObject[] head;
    [SerializeField] GameObject eyes;
    // Start is called before the first frame update
    void Start()
    {
        head[Random.RandomRange(0, head.Length)].SetActive(true);
        if (head[0].active == false)
        {
            eyes.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
