using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;

    public void setScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void showGameOverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
