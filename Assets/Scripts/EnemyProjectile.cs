using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int enemyDamage; //Enemy Damage

    //Method to determine Player Damage
    private void OnCollisionEnter(Collision collision)
    {
        //Check to see if hit object is tagged player
        if (collision.gameObject.tag == "Player")
        {
            //Get a reference to the Player Controller Class
            PlayerController targetScript = collision.gameObject.GetComponent<PlayerController>();

            //Check to see if the class is not null
            if (targetScript != null)
            {
                //Apply Damage
                targetScript.PlayerTakeDamage(enemyDamage);

                //Destroy Projectile
                Destroy(gameObject);
            }

        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
