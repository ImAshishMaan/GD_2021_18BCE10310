using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{

    public GameObject cube, retryButton, gameoveText;

    void Start()
    {
        
    }

    void Update()
    {
        if (cube.transform.position.y < -1)
        {
            retryButton.SetActive(true);
            gameoveText.SetActive(true);
        }
    }
}
