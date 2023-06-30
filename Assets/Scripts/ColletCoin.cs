using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ColletCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CointText;
    public PlayerController _playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject endPanel;


    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Sona gelindi");
            _playerController.runnigSpeed = 0;
            transform.Rotate(transform.rotation.x,180,transform.rotation.y,Space.Self);
            endPanel.SetActive(true);

            if (score >= maxScore)
            {
                PlayerAnim.SetBool("Win",true);
                
            }
            else
            {
                PlayerAnim.SetBool("Lose",true);
            }
            
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collision"))
        {
            Debug.Log("Touched Collison");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        CointText.text = "Score: " + score.ToString();
    }
}