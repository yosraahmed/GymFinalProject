using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VivePointerFinishGame : MonoBehaviour
{
    public GameObject pointerP1;
    public GameObject inputVrP1;
    public GameObject exitScreen;
    public Text player1ScoreText;
    public Text player2ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreText.text = PlayerPrefs.GetInt("player1Score", 0).ToString();
        player2ScoreText.text = PlayerPrefs.GetInt("player2Score", 0).ToString();
        if (PlayerPrefs.GetInt("PointerP1", 1)==1)
        {
            exitScreen.SetActive(true);
            pointerP1.SetActive(true);
            inputVrP1.SetActive(true);
        }
        else
        {
            exitScreen.SetActive(false);
            pointerP1.SetActive(false);
            inputVrP1.SetActive(false);
        }

        
    }
}
