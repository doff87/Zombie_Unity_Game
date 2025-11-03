using UnityEngine;

public class AddAmmo : MonoBehaviour
{
    public int addAmmo; //How much ammo to add

    //Method to add ammo
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerController targetScript = other.GetComponent<PlayerController>();

            if (targetScript != null)
            {
                targetScript.PlayerAddAmmo(addAmmo);

                Destroy(gameObject);
            }
        }
    }
}
