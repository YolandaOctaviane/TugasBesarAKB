using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField] public HighscoreData highScoreData;
    
    [Header("Score Highlight")]
    public int scoreHighlightRange;
    public CharacterSoundController sound;
    [Header("Speed Up")]
    public CharacterMoveController player;
    public float speedAdditioner;

    private int currentScore = 0;
    private int lastScoreHighlight = 0;



    private void Start()
    {
        // reset
        highScoreData.Load(out ScoreData.highScore,"highscore");
        currentScore = 0;
        lastScoreHighlight = 0;
        ScoreData.highScore = highScoreData.highscore;
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }

    public void IncreaseCurrentScore(int increment)
    {
        currentScore += increment;

        if (currentScore - lastScoreHighlight > scoreHighlightRange)
        {
            sound.PlayScoreHighlight();
            player.IncreaseGameSpeed(speedAdditioner);
            lastScoreHighlight += scoreHighlightRange;
        }
    }

    public void FinishScoring()
    {
        // set high score
        if (currentScore > ScoreData.highScore)
        {
            highScoreData.highscore = currentScore;
            ScoreData.highScore = currentScore;
        }
    }
    
    //scene
    public void BackToTitle(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
