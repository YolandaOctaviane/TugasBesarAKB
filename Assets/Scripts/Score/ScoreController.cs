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
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(Application.persistentDataPath + "/Highscore.json"),highScoreData);
        currentScore = 0;
        lastScoreHighlight = 0;
        ScoreData.highScore = highScoreData.highScore;
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
            highScoreData.highScore = currentScore;
            ScoreData.highScore = currentScore;
        }
    }
    
    //scene
    public void BackToTitle(string scene)
    {
        //save score to json
        var json = JsonUtility.ToJson(highScoreData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Highscore.json", json);

        SceneManager.LoadScene(scene);
    }
}
