using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High Score:" + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        if (gameOverScreen.activeSelf) {
            return;
        }
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);

        if (playerScore > highScore) {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreText.text = "High Score:" + highScore.ToString();
        }
    }
}
