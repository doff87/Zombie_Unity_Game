using UnityEngine;

public class DoingStuff : MonoBehaviour
{

    [SerializeField] int apples;
    public float outsideTemp;
    public string playerName;
    public bool isRaining;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("We have " + apples + " Apples!");
        Debug.Log("The temp outside is " + outsideTemp + " degrees.");
        Debug.Log("The player's name is " + playerName);
        Debug.Log("Is it raining, true or false? " + isRaining);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
