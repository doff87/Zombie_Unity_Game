using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    // What are we looking at?
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Look at stuff
        gameObject.transform.LookAt(player.transform);
    }
}
