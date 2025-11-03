using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static System.TimeZoneInfo;

public class EnemyController : MonoBehaviour
{
    
    public Transform playerTransform;// Find Player Transform
    public Transform enemyTransform;// Find Tower Transform
    public float lookDistance;// Look distance for turret
    // public float idealDistance;
    // public float shootDistance;// How far away before enemy starts blasting
    public float transitionTime;// Transition Time
    public float enemySpeed; //Enemy's Speed
    // public float projectileSpeed; //Speed of Projectile
    // public float fireRate; //Rate of fire
    // public GameObject enemyProjectile; //Identify projectile
    // public GameObject spawnPoint; //Identify spawn point
    private Animator animator;
    private Rigidbody enemyRigidbody; //Player's Rigidbody Container
    private bool isMoving;
    private bool isAnimating = false;
    private bool stopMoving = false;

    private float shotTimer; //Calculate time until next shot

    public int enemyHealth; // Enemy HP
    public Text enemyHealthText; // Enemy HP Text
    //-------------------------------Melee Attack Stuff--------------------------------
    private bool isPatrolEnemy = false;
    public float attackRange = 2f; // Distance at which the enemy can attack
    public float attackCooldown = 1.5f; // Time between attacks
    private bool isAttacking = false;
    private float lastAttackTime;
    public int attackDamage = 10; // Damage the enemy deals


    [SerializeField] string patrolpoint1Tag = "Patrolpt 1"; //Tag for enemy patrol position 1
    [SerializeField] string patrolpoint2Tag = "Patrolpt 2"; //Tag for enemy patrol position 2
    [SerializeField] string patrolpoint3Tag = "Patrolpt 3"; //Tag for enemy patrol position 3
    [SerializeField] string patrolpoint4Tag = "Patrolpt 4"; //Tag for enemy patrol position 4
    private GameObject nextPatPos; // Position for next enemy movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
                Debug.Log("Player found: " + player.name);
            }
            else
            {
                Debug.LogError("Player NOT found! Check if the tag is correct.");
            }
        }

        enemyRigidbody = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        playerTransform = GameObject.FindWithTag("Player").transform;

        //Enemy Patrol positions
        if (gameObject.CompareTag("PatrolEnemy"))
        {
            isPatrolEnemy = true;

            // Initialize patrol points
            GameObject enPat1 = GameObject.FindWithTag(patrolpoint1Tag);
            GameObject enPat2 = GameObject.FindWithTag(patrolpoint2Tag);
            GameObject enPat3 = GameObject.FindWithTag(patrolpoint3Tag);
            GameObject enPat4 = GameObject.FindWithTag(patrolpoint4Tag);
            nextPatPos = enPat2;
        }

    }

    // Update is called once per frame
    void Update()
    {
        animator.applyRootMotion = true;

        if (enemyHealth <= 0)
        {
            stopMoving = true;
            return;
        }

        GameObject enPat1 = GameObject.FindWithTag(patrolpoint1Tag);
        GameObject enPat2 = GameObject.FindWithTag(patrolpoint2Tag);
        GameObject enPat3 = GameObject.FindWithTag(patrolpoint3Tag);
        GameObject enPat4 = GameObject.FindWithTag(patrolpoint4Tag);

        // Check the distance to the player
        float distanceToPlayer = Vector3.Distance(playerTransform.position, enemyTransform.position);
        //Dependent on player position turn and move to player, turn to face the player only, or face and move towards next patrol point
        if (distanceToPlayer <= attackRange && !isAttacking && Time.time >= lastAttackTime + attackCooldown)
        {
            StartCoroutine(PerformAttack());
        }

        else if (distanceToPlayer <= lookDistance && stopMoving == false)
        {
            //transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            FacePlayer();
            // Moving to player until at ideal distance
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerTransform.position, enemySpeed * Time.deltaTime);
            isMoving = MoveTowards(playerTransform.position);

        }
        /*else if (distanceToPlayer <= lookDistance)
        {
            //Face the player
            FacePlayer();
        }*/
        else if (stopMoving == false && isPatrolEnemy)
        {
             
            //Face in direction of movement
            FaceMovementDirection();
            isMoving = MoveTowards(nextPatPos.transform.position);
            //Move in direction
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPatPos.transform.position, enemySpeed * Time.deltaTime);
            //Logic to swap to next point

            if (enemyRigidbody.transform.position == enPat2.transform.position) nextPatPos = enPat3;
            else if (enemyRigidbody.transform.position == enPat3.transform.position) nextPatPos = enPat4;
            else if (enemyRigidbody.transform.position == enPat4.transform.position) nextPatPos = enPat1;
            else if (enemyRigidbody.transform.position == enPat1.transform.position) nextPatPos = enPat2;

        }

        /*if (distanceToPlayer <= lookDistance && distanceToPlayer <= shootDistance && Time.time >= shotTimer)
        {
            shotTimer = Time.time + 1f / fireRate;//Reset shot cooldown timer
            GameObject projectile = Instantiate(enemyProjectile, spawnPoint.transform.position, spawnPoint.transform.rotation); //Create the projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();//Get the rigidbody from the projectile
            rb.linearVelocity = projectile.transform.forward * projectileSpeed;//Apply velocity to rigidbody
            Destroy(projectile, 5f);//Destroy the projectiles
        }*/

        //Update Animation State
        animator.SetBool("isWalking", isMoving);

        enemyHealthText.text = enemyHealth.ToString();
    }

    bool MoveTowards(Vector3 targetPosition, float stopDistance = 1.5f)
    {
        float step = enemySpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            return true;
        }
        return false;
    }

    void FacePlayer()
    {

        //Determine the direction to the player
        Vector3 directionToPlayer = playerTransform.position - enemyTransform.position;

        //Rotate the turret towards the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        //Smooth the transition
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, lookRotation, transitionTime * Time.deltaTime);


    }

    void FaceMovementDirection()
    {
        //Determine the direction to the next patrol point
        Vector3 directionToPatPoint = nextPatPos.transform.position - enemyTransform.position;
        //Identify what the starting rotation is
        Quaternion lookRotation = Quaternion.LookRotation(directionToPatPoint);

        //Smooth the transition
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, lookRotation, transitionTime * Time.deltaTime);

    }

    public void EnemyDamage(int damage)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damage;
            enemyHealthText.text = enemyHealth.ToString();

            if (enemyHealth > 0)
            {
                if (enemyRigidbody != null)
                {
                    stopMoving = true;
                    enemyRigidbody.linearVelocity = Vector3.zero; // Stop movement
                    enemyRigidbody.angularVelocity = Vector3.zero; // Stop rotation
                    StartCoroutine(ResumeMovementAfterStagger(0.2f)); // Short stagger time
                }

                animator.SetTrigger("isDamaged");
            }

            else StartCoroutine(HandleDeath());
        }
        
    }

    private IEnumerator ResumeMovementAfterStagger(float staggerDuration)
    {
        yield return new WaitForSeconds(staggerDuration); // Shorter stagger duration
        enemyRigidbody.isKinematic = false;
        stopMoving = false;
    }

    private IEnumerator HandleDeath()
    { 

        // Trigger the death animation
        animator.SetTrigger("isKilled");

        if (enemyRigidbody != null)
        {
            enemyRigidbody.linearVelocity = Vector3.zero; // Stops unwanted movement
            enemyRigidbody.angularVelocity = Vector3.zero; // Stops rotation issues
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

        Destroy(gameObject, 1.3f);
        
    }

    //Melee attack
    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        // Trigger attack animation
        animator.SetTrigger("isAttacking");

        // Ensure movement and idle animations stop immediately
        animator.SetBool("isWalking", false);

        yield return new WaitForSeconds(0.6f); 

        // Deal damage if the player is still in range
        if (Vector3.Distance(playerTransform.position, enemyTransform.position) <= attackRange)
        {
            PlayerController playerController = playerTransform.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.PlayerTakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(0.4f);

        isAttacking = false;
    }
}