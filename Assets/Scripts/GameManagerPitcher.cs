using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerPitcher : MonoBehaviour
{
    
    public int strikeCount;
    public int pitchCount;

    [SerializeField] TMPro.TextMeshProUGUI strikeCountText;
    [SerializeField] TMPro.TextMeshProUGUI pitchCountText;

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

    // Update is called once per frame

    public void ProcessStrikeCount(int strikeCount)
    {
        strikeCountText.text = "StrikeCount: " + strikeCount;
        if (strikeCount == 3 && pitchCount < 15)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene(4);
        }
    }
    public void ProcessPitchCount(int pitchCount)
    {
        pitchCountText.text = "PitchCount: " + pitchCount;
        if (pitchCount == 15 && strikeCount < 3)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(3);

        }
    }
        void Update()
    {

    }
}
