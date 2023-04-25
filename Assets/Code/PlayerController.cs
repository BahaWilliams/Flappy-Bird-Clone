using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField] float jumpForce = 5f;
    public GameObject loseScreenUI;
    [SerializeField] int score, highScore;
    [SerializeField] Text scoreUI, highScoreUI;
    string HIGHSCORE = "HIGHSCORE";

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(HIGHSCORE);
    }

    void Update()
    {
        PlayerJump();
    }


    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.singleton.PlaySound(0);
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obsticale"))
        {
            PlayerLose();
        }
    }

    private void PlayerLose()
    {
        AudioManager.singleton.PlaySound(1);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HIGHSCORE, highScore);
        }

        highScoreUI.text = "HighScore: " + highScore.ToString();
        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            AddScore();
        }
    }

    private void AddScore()
    {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }
}
