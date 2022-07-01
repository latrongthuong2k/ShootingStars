using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject text;
    private float GameStartCount;
    public float time;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        GameStartCount = 1f;
        time = 0.0f;
        text.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        GameStartCount -= Time.deltaTime;
        if (GameStartCount <= 0)
        {
            time += Time.deltaTime;
            timeText.text = "生存時間 : " + time.ToString("F2");
        }
    }
}
