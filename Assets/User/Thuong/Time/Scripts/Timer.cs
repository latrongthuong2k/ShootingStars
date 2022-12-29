using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time;

    private float GameStartCount;
    public GameObject timer;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        GameStartCount = 1f;
        time = 400f;
        timer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        GameStartCount -= Time.deltaTime;
        if (GameStartCount <= 0 && SpawnObj.AllowSpawn == true)
        {
            time -= Time.deltaTime;
            timeText.text = "Fuel left : " + time.ToString("F2");
        }
    }
}
