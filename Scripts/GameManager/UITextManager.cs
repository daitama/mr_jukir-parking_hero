using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    public static UITextManager instance;

    public Text score_text;
    public Text time_text;
    public Text level_text;

    public int score = 0;
    int level = 1;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(time_text.text);
        score_text.text = "Score: " + score.ToString();
        time_text.text = "Time: ";
        level_text.text = "Level: " + level.ToString();
        Debug.Log(time_text.text);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.Round(Time.time);
        time_text.text = "Time: " + time.ToString() + "s";
    }

    public void AddScore()
    {
        score += 1;
        score_text.text = "Score: " + score.ToString();
    }
    public void SetLevel(int level)
    {
        level = level;
        level_text.text = "Level: " + level.ToString();
    }

}
