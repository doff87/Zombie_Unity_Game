using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject restartButton;//Restart Button
    public GameObject quitButton;//Quit Button
    
    public PlayerController playerController; //Player Controller

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if the palyer hits the esc key
        if (Input.GetKeyDown(KeyCode.Escape) && playerController.playerHealth > 0)
        {
            //Time Control Method
            TimeControl();
        }
    }

    //Control Time Management
    public void TimeControl()
    {
        //Pause the game
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            restartButton.SetActive(true);
            quitButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //Unpause the game
        else if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            restartButton.SetActive(false);
            quitButton.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    //Restart Method
    public void RestartGame() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Quit Method
    public void QuitGame()
    {
        Application.Quit();
    }
}
