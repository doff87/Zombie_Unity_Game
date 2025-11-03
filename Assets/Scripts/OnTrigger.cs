using UnityEngine;
using UnityEngine.UI;

public class OnTrigger : MonoBehaviour
{
    public GameObject victoryText;
    public GameController gameManager;
    //Turn OFF/ON
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Victory(gameManager);
        }
    }

    public void Victory(GameController gameController)
    {
        //Pause the game
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            victoryText.SetActive(true);
            gameController.restartButton.SetActive(true);
            gameController.quitButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}   
