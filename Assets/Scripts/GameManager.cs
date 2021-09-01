using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameOver;

    private int score;
    public GameObject titleScreen;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(5);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameOver = false;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
