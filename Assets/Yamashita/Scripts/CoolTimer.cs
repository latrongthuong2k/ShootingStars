using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimer : MonoBehaviour
{
    [SerializeField] GameObject text;
    public float coolTime;
    public Text coolTimeText;
    // Start is called before the first frame update
    void Start()
    {
        coolTime = 5.0f;
        text.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        coolTime -= Time.deltaTime;
        coolTimeText.text = "クールタイム : " + coolTime.ToString("F1");

        if (coolTime <= 0)
        {
            coolTime = 0;

        }
    }
}
