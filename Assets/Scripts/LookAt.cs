using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //public Transform playerTransform;// Find Player Transform
    [SerializeField] string playerTag = "Player"; //Get player tag
    [SerializeField] Transform towerTransform;// Find Tower Transform
    [SerializeField] Transform enemyTransform;// Find Enemy Transform
    [SerializeField] float lookDistance;// Look distance for turret
    [SerializeField] float transitionTime;// Transition Time


    // Start is called before the first frame update
    void Start() 
    { 
    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerTransform = GameObject.FindWithTag(playerTag);
        // Check the distance to the player
        float distanceToPlayer = Vector3.Distance(playerTransform.transform.position, towerTransform.position);
        //If player is close enough, turn to look
        if (distanceToPlayer <= lookDistance)
        {
            //Face the player
            FacePlayer();
        }
        else
        {
            //If not, reset rotation
            ResetTowerRotation();
        }
    }

    //Create method to look at the player
    void FacePlayer()
    {
        GameObject playerTransform = GameObject.FindWithTag(playerTag);
        //Determine the direction to the player
        Vector3 directionToPlayer = playerTransform.transform.position - towerTransform.position;
        
        //Rotate the turret towards the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        //Smooth the transition
        towerTransform.rotation = Quaternion.Slerp(towerTransform.rotation, lookRotation, transitionTime * Time.deltaTime);
    }

    //Create a method to reset tower rotation
    void ResetTowerRotation()
    {
        //Identify what the starting rotation is
        Quaternion lookRotation = Quaternion.identity;

        //Reset rotation of the turret
        towerTransform.rotation = Quaternion.Slerp(towerTransform.rotation, lookRotation, transitionTime * Time.deltaTime);
    }
}
