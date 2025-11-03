using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float newSpeed;//new Speed
    public float duration;//Duration
    public string message;//Message

    public GameObject cleanUp;//Area to temporarily hold until deletion

    //Create a Method to determine when the power up happens
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController targetScript = collision.gameObject.GetComponent<PlayerController>();

            if(targetScript != null )
            {
                StartCoroutine(targetScript.AddSpeedCoroutine(newSpeed, duration, message));

                StartCoroutine(WaitForDurationCoroutine(duration + 1f));
            }

            gameObject.transform.position = cleanUp.transform.position;
        }
    }

    private IEnumerator WaitForDurationCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }

}
