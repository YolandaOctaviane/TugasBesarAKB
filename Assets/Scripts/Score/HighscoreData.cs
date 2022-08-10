using UnityEngine;

[CreateAssetMenu(fileName = "HighscoreData", menuName = "HighscoreData", order = 0)]
public class HighscoreData : ScriptableObject
{
    public int highscore;
    
    public void Save(int highscore, string name)
    {
        this.highscore = highscore;
        FileHandler.SaveToJSON(this,name);
    }

    public void Load(out int highscore, string name)
    {
        FileHandler.ReadFromJSONOverwrite(name,this);
        highscore = this.highscore;
    }
}
