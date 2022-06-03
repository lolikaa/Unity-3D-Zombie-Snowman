/// <summary>
/// Health.cs
/// Author: MutantGopher
/// This is a sample health script.  If you use a different script for health,
/// make sure that it is called "Health".  If it is not, you may need to edit code
/// referencing the Health component from other scripts
/// </summary>

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public bool canDie = true;					// Whether or not this health can die
	
	public float startingHealth = 100.0f;		// The amount of health to start with
	public float maxHealth = 100.0f;			// The maximum amount of health
	private float currentHealth;				// The current ammount of health

	public bool replaceWhenDead = false;		// Whether or not a dead replacement should be instantiated.  (Useful for breaking/shattering/exploding effects)
	public GameObject deadReplacement;			// The prefab to instantiate when this GameObject dies
	public bool makeExplosion = false;			// Whether or not an explosion prefab should be instantiated
	public GameObject explosion;				// The explosion prefab to be instantiated

	public bool isPlayer = false;				// Whether or not this health is the player
	public GameObject deathCam;					// The camera to activate when the player dies

	private bool dead = false;                  // Used to make sure the Die() function isn't called twice


	private Vector3 Min;
	private Vector3 Max;
	private float _xAxis;
	private float _yAxis;
	private float _zAxis; //If you need this, use it
	private Vector3 _randomPosition;
	public bool _canInstantiate;

	// Use this for initialization
	void Start()
	{
		// Initialize the currentHealth variable to the value specified by the user in startingHealth
		currentHealth = startingHealth;
		SetRanges();
	}

    private void Update()
    {
		_xAxis = UnityEngine.Random.Range(Min.x, Max.x);
		_yAxis = UnityEngine.Random.Range(Min.y, Max.y);
		_zAxis = UnityEngine.Random.Range(Min.z, Max.z);
		_randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
	}

    public void ChangeHealth(float amount)
	{
		// Change the health by the amount specified in the amount variable
		currentHealth += amount;

		// If the health runs out, then Die.
		if (currentHealth <= 0 && !dead && canDie)
			Die();

		// Make sure that the health never exceeds the maximum health
		else if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}


	public void Die()
	{
		// This GameObject is officially dead.  This is used to make sure the Die() function isn't called again
		dead = true;

		// Make death effects
		if (replaceWhenDead)
		//	Instantiate(deadReplacement, transform.position, transform.rotation);
			Instantiate(deadReplacement, _randomPosition, Quaternion.identity);
			Update();
			Instantiate(deadReplacement, _randomPosition, Quaternion.identity);
		
		if (makeExplosion)
			Instantiate(explosion, transform.position, transform.rotation);

		if (isPlayer && deathCam != null)
			deathCam.SetActive(true);

		// Remove this GameObject from the scene
		Destroy(gameObject);
	}

	private void SetRanges()
	{
		Min = new Vector3(-51, 1, -35); //Random value.
		Max = new Vector3(50, 1, 62); //Another ramdon value, just for the example.
	}
}
