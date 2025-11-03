using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public int addHealth;//How much health to add

    //Method to add health
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController targetScript = other.gameObject.GetComponent<PlayerController>();

            if (targetScript != null && targetScript.playerHealth < targetScript.playerHealthMax)
            {
                targetScript.PlayerAddHealth(addHealth);

                Destroy(gameObject);
            }
        }
    }
}
