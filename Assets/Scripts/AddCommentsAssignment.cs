using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCommentsAssignment : MonoBehaviour
{
    public float moveSpeed = 5f; //Player move speed
    public float rotationSpeed = 200f; //Turn speed of player

    private float timer; //Declaring the current time, when 0 game is over
    public float maxTime = 120f; //Max time player can stay in game

    public int maxHealth = 100; //Player's max hp
    private int currentHealth; //Declares but does not set HP, initial HP = to max hp

    private int score; //Declaring player score

    void Start() //Executes at beginning of program
    {
        currentHealth = maxHealth; //Initializing player health to max health
        timer = maxTime; //Initializng timer time to max time player can stay in level
    }

    void Update() //Executes once per frame
    {
        timer -= Time.deltaTime; //Timer decreases over time independent of frame rate

        if (timer <= 0) //Executes when all time for the game has elapsed
        {
            Debug.Log("Time's up! Game Over!"); //When framerate is below zero game ends, or at least a message is sent to the console stating it has ended
        }

        HandlePlayerInput(); //Calls the method to handle player movement
    }

    void HandlePlayerInput() //Method to handle player  inputs
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //Collects player horizontal movement inputs
        float verticalInput = Input.GetAxis("Vertical"); //Collects player vertical movement inputs

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized; //Sets player velocity as a function of input

        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime); //Sets player rotation speed as a function of time (to smooth), rotation sensitivity, and magnitude of player input

        transform.Translate(movement * moveSpeed * Time.deltaTime); //Sets player movement speed as a function of player velocity, time, and move speed

        if (Input.GetKeyDown(KeyCode.D)) //If D is held down
        {
            TakeDamage(10); //Call TakeDamage method with 10 as an argument - presumably causing the player to take 10 damage
        }

        if (Input.GetKeyDown(KeyCode.S)) //If S is held down
        {
            IncreaseScore(50); //Call IncreaseScore method with 50 as an argument - presumably causing score to increase by 50
        }
    }

    void OnCollisionEnter(Collision collision) //Method to handle player collision with objects tagged Obstacle
    {
        if (collision.gameObject.CompareTag("Obstacle")) //If player rigid body makes contact with rigidbody tagged with Obstacle
        {
            Debug.Log("Player collided with an obstacle!"); //Outputs to the console that player collided with an obstacle
            TakeDamage(20); //Call TakeDamage method with 20 as an argument - presumably causing the player to take 20 damage
        }
    }

    void OnTriggerEnter(Collider other) //Method to fire when a trigger object is touched by the player
    {
        if (other.CompareTag("Pickup")) //If the object is tagged with pickup
        {
            Debug.Log("Player picked up a coin!"); //Outputs to the console that the player picked up a coin
            IncreaseScore(10); //Call IncreaseScore method with 10 as an argument - presumably causing score to increase by 10
            Destroy(other.gameObject); //Deletes object after player triggers it
        }
    }

    void TakeDamage(int damage) //Method to handle player taking damage, taking an int as an argument
    {
        currentHealth -= damage; //Subtracts the int argument from the current health of the player

        if (currentHealth <= 0) //If the loss of health causes the player's hp to go to 0 or less
        {
            Debug.Log("Player has run out of health! Game Over!"); //Displays to the console that the game is over due to player hp
        }
    }

    void IncreaseScore(int points) //Method to handle increasing player score, taking an int as a method
    {
        score += points; //Increases player score by the int argument
        Debug.Log("Score increased! Current Score: " + score); // Echoes to the player whenever player score is increased with the current score
    }
}

