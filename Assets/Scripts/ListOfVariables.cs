using UnityEngine;

public class ListOfVariables : MonoBehaviour
{
    [SerializeField] string playerName = "Player1";
    public string characterClass = "Monk";
    [SerializeField] string assignedTeam = "active party";
    private float walkSpeed = 3.4f;
    private float runSpeedMulti = 2.3f;
    public int armorCount = 4;
    public bool weaponEquipped = true;
    [SerializeField] int maxArmorCount = 8;
    [SerializeField] int playerLevel = 13;
    public int playerGold = 436;
    public int totalMagicSlots = 6;
    public int hp = 74;
    public int xp = 6057;
    [SerializeField] bool currentlyBuffed = false;
    public bool playerAlive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Your name is " + playerName + ".");
        Debug.Log("You are of the " + characterClass + " class." );
        Debug.Log("You are in the " + assignedTeam + ".");
        Debug.Log("You walk at " + walkSpeed + " feet per second.");
        Debug.Log("When sprinting your walk speed is multiplied by " + runSpeedMulti + ".");
        Debug.Log("You currently have " + armorCount + " pieces of armor equipped.");
        Debug.Log("Currently your wield status is " + weaponEquipped + ".");
        Debug.Log("You can equip up to " + maxArmorCount + " pieces of armor before becoming overencumbered.");
        Debug.Log("You are level " + playerLevel + ".");
        Debug.Log("You have " + playerGold + " gold coins.");
        Debug.Log("You may memorize up to " + totalMagicSlots + " spells during a long rest.");
        Debug.Log("You have " + hp + " hit points.");
        Debug.Log("You have " + xp + " experience points.");
        Debug.Log("Currently your buff status is " + currentlyBuffed + ".");
        Debug.Log("Currently your life status is " + playerAlive + ".");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
