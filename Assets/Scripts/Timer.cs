using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time = 0f;
    TMP_Text timeString;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeString = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minute = (int)(time / 60f);
        int second = (int)(time % 60f);
        int milisecond = (int)((time * 1000f) % 1000f);
        timeString.text = $"Timer: {minute:00}:{second:00}:{milisecond:00}";
    }
}
