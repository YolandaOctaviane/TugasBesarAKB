using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public HighscoreData highScoreData;

    // reset score jadi 0 (biar kehapus play sambil aktifin script ini, terus keluar non aktifin script ini )
    public void Start()
    {
        //highScoreData.Save(0, "highscore"); 
    }
    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
