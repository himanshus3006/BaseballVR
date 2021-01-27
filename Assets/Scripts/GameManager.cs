using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Config
    public int score;
    public int strikeCount;
    public int pitcherScore;

    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField]TMPro.TextMeshProUGUI strikeCountText;
    [SerializeField] TMPro.TextMeshProUGUI pitcherScoreText;

    private void Awake()
    {
        int GameManagerNumber = FindObjectsOfType<GameManager>().Length;
        if (GameManagerNumber > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
      
    }
    

    public void ProcessScore (int index)
    {
        switch(index)
        {
            case 1:
                score += 1;
                break;
            case 2:
                score += 2;
                break;

            case 3:
                score += 4;
                break;

            case 4:
                score += 5;
                break;
        }

        Debug.Log("Score " + score);
        scoreText.text = "Score:" + score;
        if(score >  150)
        {
            SceneManager.LoadScene(4);
        }
    }
    // Update is called once per frame

    public void ProcessStrikeCount(int strikeCount, int pitcherScore)
    {
       

        pitcherScoreText.text = "PitcherScore:" + pitcherScore;
        strikeCountText.text = "StrikeCount: " + strikeCount;
        if (strikeCount == 15)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(3);
        }
    }
    void Update()
    {
        
    }
}
