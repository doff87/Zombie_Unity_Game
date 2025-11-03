using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour 
{
    public GameObject restartButton;//Restart Button
    public GameObject quitButton;//Quit Button
    public float playerSpeed; //Player's Speed
    public float rotationSensitivity; //Rotation Sensitivity
    //--------------------------------------------------------------------------------------------
    public float verticalSensitivity; //Vertical Sensitivity 
    public Transform playerCamera; //Camera Variable
    public float projectileSpeed; //Speed of Projectile
    public float fireRate; //Rate of fire
    public int ammoCount; //Ammo Count
    public GameObject playerProjectile; //Identify projectile
    public GameObject spawnPoint; //Identify spawn point
    //--------------------------------------------------------------------------------------------
    public int playerHealth; //Player Health
    public int playerHealthMax; // Max HP
    public Text healthText;//Health Text
    public Text ammoText;//Ammo Text
    public GameObject gameOverText;//Game Over text Game Object
    //----------------------------------------Power Up--------------------------------------------
    public Text powerUpText; //Text Blob
    private float originalSpeed;//Original Speed
    //--------------------------------------------------------------------------------------------
    private Rigidbody playerRigidbody; //Player's Rigidbody Container
    //--------------------------------------------------------------------------------------------
    private float upDownRotation; //Limit for vertical rotation
    private float shotTimer; //Calculate time until next shot


    //Start is called before the first frame update
    void Start()
    {
        //Apply our Original Speed
        originalSpeed = playerSpeed;

        //Find the Rigidbody
        playerRigidbody = gameObject.GetComponent<Rigidbody>();

        //Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;

        //Hide Cursor
        Cursor.visible = false;

    }




    //Update is called once per frame
    void Update()
    {
        //Update Health Text
        healthText.text = "Health: " + playerHealth.ToString();
        
        //Update Ammo Text
        ammoText.text = "Ammo: " + ammoCount.ToString();


        if (Time.timeScale == 1f)
        {
            //Calculate the player's velocity
            //                                                                               x                y                z  
            Vector3 playerVelocity = gameObject.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * playerSpeed;

            //Apply the velocity
            playerRigidbody.linearVelocity = playerVelocity;

            //Apply rotation
            gameObject.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotationSensitivity);

            //Get camera rotation
            upDownRotation = Mathf.Clamp(Input.GetAxis("Mouse Y") * -verticalSensitivity + upDownRotation, -60f, 60f);

            //Apply camera rotation
            playerCamera.localRotation = Quaternion.Euler(new Vector3(upDownRotation, 0f, 0f));
        }
        //Shooting Stuff

        //Can we shoot
        if (Input.GetButton("Fire1") && ammoCount > 0 && Time.time >= shotTimer && Time.timeScale == 1f)
        {
            ammoCount -= 1; //Reduce Ammo Count by 1
            shotTimer = Time.time + 1f / fireRate;//Reset shot cooldown timer
            GameObject projectile = Instantiate(playerProjectile, spawnPoint.transform.position, spawnPoint.transform.rotation); //Create the projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();//Get the rigidbody from the projectile
            rb.linearVelocity = projectile.transform.forward * projectileSpeed;//Apply velocity to rigidbody
            Destroy(projectile, 5f);//Destroy the projectiles
        }
    }

    //Create a player takes damage method
    public void PlayerTakeDamage(int damage)
    {
        //Apply Damage
        playerHealth -= damage;

        //Check if below Zero
        if (playerHealth <= 0)
        {
            //Turn on Game Over Text
            gameOverText.SetActive(true);

            //Set player health to zero
            playerHealth = 0;

            restartButton.SetActive(true);
            quitButton.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //Freeze Time
            Time.timeScale = 0f;
        }
        //Destroy projectile

    }

    //Method to determine how to add health
    public void PlayerAddHealth(int health)
    {
        if (playerHealth <= playerHealthMax - health)
        {
            playerHealth += health;
        }
        
        else
        {
            playerHealth = playerHealthMax;
        }
    }
    //Method to determine how to add ammo
    public void PlayerAddAmmo(int ammo)
    {
        ammoCount += ammo;
    }

    //Method for Adjusting Speed
    public IEnumerator AddSpeedCoroutine(float speed, float duration, string message)
    {
        //Set the New Speed
        playerSpeed = speed;

        //Set the Power Up Method
        powerUpText.text = message;

        //Wait for the duration
        yield return new WaitForSeconds(duration);

        //Set Original Speed
        playerSpeed = originalSpeed;

        //Remove Message
        powerUpText.text = "";

    }

}
