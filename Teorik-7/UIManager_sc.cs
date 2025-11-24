using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    TMP_Text gameOverText;

    [SerializeField]
    Image liveImg;

    [SerializeField]
    Sprite[] liveSprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score : 0";
        liveImg.sprite = liveSprites[3];
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int CurrentLives)
    {
        liveImg.sprite = liveSprites[CurrentLives];
        if (CurrentLives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlickerRoutine());

        }
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
