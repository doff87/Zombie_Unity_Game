using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Projectile : MonoBehaviour
{

    //How much damage does it do
    public int damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Target")
        {
            
            Target targetScript = collision.gameObject.GetComponent<Target>();

            //If the script exists, do stuff
            if(targetScript != null)
            {
                //Do Stuff
                targetScript.TakingDamage(damageAmount);
            }

            //Destroy itself
            Destroy(gameObject);

        }
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PatrolEnemy")
        {
            EnemyController enemyScript = collision.gameObject.GetComponent<EnemyController>();

            if (enemyScript != null)
            {
                enemyScript.EnemyDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
