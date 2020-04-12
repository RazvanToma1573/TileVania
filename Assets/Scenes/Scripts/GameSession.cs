using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int coins = 0;

    [SerializeField] Text liveText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        liveText.text = playerLives.ToString();
        scoreText.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPlayerDeath()
    {
        if (this.playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        this.playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        liveText.text = playerLives.ToString();
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void addCoin(int points)
    {
        coins += points;
        scoreText.text = coins.ToString();
    }
}
