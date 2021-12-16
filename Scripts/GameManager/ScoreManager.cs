using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text score_text;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score_text.text = "Score: " + score.ToString();
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        score_text.text = "Score: " + score.ToString();
    }
}
