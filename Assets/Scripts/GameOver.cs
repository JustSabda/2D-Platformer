using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text txScore;
    public Text txHighScore;
    Text txSelamat;
    int highscore;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HS", 0);
        highscore = PlayerPrefs.GetInt("HS", 0);
        if(Data.score > highscore)
        {
            highscore = Data.score;
            PlayerPrefs.SetInt("HS", highscore);
        }
        else if (EnemyController.EnemyKilled == 4)
        {
            SceneManager.LoadScene("Congratulation");
        }
        txHighScore.text = "Highscores: " + highscore;
        txScore.text = "Score: " + Data.score;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            PlayerPrefs.SetInt("HS", 0);
        }
    }

    public void Replay()
    {
        Data.score = 0;
        EnemyController.EnemyKilled = 0;
        SceneManager.LoadScene("Gameplay");
    }
}
