using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            gameOver = false;
            HealthController.god_mode = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SetGameOver()
    {
        gameOver = true;
    }

    public void EndGame()
    {
        gameOverText.SetActive(true);
    }
}
