using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Identify the cube

    public GameObject myCube;

    // How fast does the cube rotate

    public float rotateSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate the cube
        myCube.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
