using UnityEngine;
using UnityEngine.SceneManagement;
using Game.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private Text livesText = null;
    [SerializeField] private Text scoreText = null;
    private void Awake()
    { 
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        livesText.SetText(playerLives.ToString());
        scoreText.SetText(score.ToString());
    }
    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.SetText(score.ToString());
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
        ScenePersist.Instance.ResetScenePersist();
        Destroy(gameObject);
    }

    private void TakeLife()
    {
        playerLives--;
        livesText.SetText(playerLives.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
