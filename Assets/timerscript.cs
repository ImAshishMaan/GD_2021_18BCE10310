using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerscript : MonoBehaviour
{
    float currtime;
    bool newGroundInstanciated;
    readonly List<Vector3> pos = new List<Vector3>() { new Vector3(9, 0, 0), new Vector3(-9, 0, 0), new Vector3(0, 0, 9), new Vector3(0, 0, -9) } ;

    void Start()
    {
        newGroundInstanciated = false;
        currtime = 4f;
    }


    void Update()
    {
        currtime -= 1 * Time.deltaTime;
        gameObject.transform.Find("Canvas").Find("Timer").GetComponent<TMP_Text>().text=currtime.ToString().Substring(0,4);

        if (!newGroundInstanciated && currtime < 2f)
        {
            newGroundInstanciated = true;

            int index = Random.Range(0, pos.Capacity);
            Vector3 newpos = new Vector3(gameObject.transform.position.x + pos[index].x, 0, gameObject.transform.position.z + pos[index].z);
            Instantiate(gameObject, newpos, Quaternion.identity);
        }
 
        if (currtime <= 0)
        {
            string s = GameObject.Find("Score").GetComponent<TMP_Text>().text;
            print(s);
            s = s.Substring(7);
            int score = int.Parse(s);

            GameObject.Find("Score").GetComponent<TMP_Text>().text = "Score: " + (score + 1).ToString();
            Destroy(gameObject);
        }
    }
}