using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecha : MonoBehaviour {

	bool isMeleeMode = false;
	bool isHovering = false;

	float speed = 3.0f;
	float jumppower = 10.5f;

	public GameObject bulletPrefab;
	public GameObject meleePrefab;

	//melee
	private bool attacking =false;
	private float attackTimer = 0;
	private float attackCoolDown = 0.5f;
	public Collider2D attackTrigger;

	void Awake()
	{
		attackTrigger.enabled = false;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate(Vector3.down * Time.deltaTime * speed);
			GetComponent<Rigidbody2D> ().gravityScale = 5.0f;
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed);	
		}

		if (Input.GetKey (KeyCode.W)) 
		{
			if (isHovering == false) 
			{
				transform.Translate(Vector3.up * Time.deltaTime * jumppower);
				GetComponent<Rigidbody2D> ().gravityScale = 1.0f;
			}

		}

		if (Input.GetKeyDown (KeyCode.RightShift)) 
		{
			if(isMeleeMode == false)
			{
				GetComponent<SpriteRenderer>().color = Color.red;
			}

			else
			{
				GetComponent<SpriteRenderer>().color = Color.white;
			}
			isMeleeMode =  !isMeleeMode;
		}
        /*
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			mouseDirection.z = 0.0f;
			mouseDirection.Normalize();

			if (isMeleeMode == false) {
				GameObject newBullet = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
				newBullet.GetComponent<Bullet> ().direction = mouseDirection;
			} 
		}
        */
		//melee
		if(Input.GetKeyDown("f") && !attacking)
		{
			attacking = true;
			attackTimer = attackCoolDown;
			Debug.Log("I am attacking");
		}

		if(attacking)
		{
			if(attackTimer > 0)
			{
				attackTimer -= Time.deltaTime;
			}
			else
			{
				attacking = false;
				attackTrigger.enabled = false;
				Debug.Log("I am done attacking");
			}
		}

		if (transform.position.y > 1.1f) 
		{
			isHovering = true;
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
			GetComponent<SpriteRenderer>().color = Color.yellow;
		}
		else 
		{
			isHovering = false;
			GetComponent<Rigidbody2D> ().constraints = ~RigidbodyConstraints2D.FreezePositionY;
			GetComponent<SpriteRenderer>().color = Color.white;
		}

	}
}
