using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public Text scoreText;
    [SerializeField] private int score;
    private int currentScore;

    private Vector2 originalScorePosition; // Store the original position of the score

    public void Start()
    {
        originalScorePosition = scoreText.rectTransform.anchoredPosition; // Store the original position
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore()
    {
        while (NewBehaviourScript.isAlive)
        {
            yield return new WaitForSeconds(0.1f);
            AddScore();
        }

        // Player is no longer alive, move the score to the middle
        MoveScoreToMiddle();
    }

    private void MoveScoreToMiddle()
    {
        Vector2 middlePosition = new Vector2(0, -400);
        scoreText.rectTransform.anchoredPosition = middlePosition;

        // Display "Your Score: " along with the score
        UpdateScoreText(true);
    }

    public void Restart()
    {
        score = 0;
        UpdateScoreText(false); // Update without the "Your Score: " prefix
        scoreText.rectTransform.anchoredPosition = originalScorePosition;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EnableButtons()
    {
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    private void AddScore()
    {
        if (scoreText != null)
        {
            
            if (int.TryParse(scoreText.text, out currentScore))
            {
                currentScore++;
                scoreText.text = currentScore.ToString();
            }
        }
    }

    // Helper method to update the UI Text with the current score
    private void UpdateScoreText(bool includePrefix)
    {
        if (scoreText != null)
        {
            if (includePrefix)
            {
                scoreText.text = "Your Score: " + currentScore.ToString();
            }
            else
            {
                scoreText.text = score.ToString();
            }
        }
    }
}
