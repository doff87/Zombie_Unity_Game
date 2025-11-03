using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    //How much health do we have
    public int targetHealth;

    //What are we updating
    public Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update the health text with hit points
        healthText.text = targetHealth.ToString();
    }

    //Method to take damage
    public void TakingDamage(int damage)
    {
        //Reduce Health
        targetHealth -= damage;

        //Check if target still alive
        if (targetHealth <= 0)
        {
            //If not, destroy the target
            Destroy(gameObject);
        }


    }
}
