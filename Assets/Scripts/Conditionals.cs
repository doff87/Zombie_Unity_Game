using UnityEngine;

public class Conditionals : MonoBehaviour


       
{

    public int playerHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* if (number >= 0)
        {
            Debug.Log("The Number is positive.");
        }

        else
        {
            Debug.Log("The Number is negative.");
        } */

        /* if (number <= 5 || number >= 7)
         {
             Debug.Log("The Number is not 6.");
         }

         else 
         {
             Debug.Log("The number is 6.");      
         } */

        if (playerHealth >= 100)
        {
            Debug.Log("The player is at full health.");

        }

        else if (playerHealth >= 1 && playerHealth <= 99)
        {
            Debug.Log("The player is wounded.");
        }

        else
        {
            Debug.Log("The player is dead.");
        }
    }
}
