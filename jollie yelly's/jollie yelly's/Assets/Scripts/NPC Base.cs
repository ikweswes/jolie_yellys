using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour {

	public float range;

	protected string _name;
	protected float health = 1;
	protected float speed = 1;
	protected bool friendly = true;
	protected float attackCooldown = 1;
	protected float damageAbleToDeal = 1;
	protected RaycastHit right;
	protected RaycastHit left;
	protected PlayerScript player;

	bool _attacking = false;
	Rigidbody rigidboddy;


	void Start () {
		rigidboddy = GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		OnStart();
	}
	
	// Update is called once per frame
	void Update () {

		if(friendly == false)
		{
			if (Physics.Raycast(this.transform.position,Vector3.right,out right) && right.distance < range && right.collider == GameObject.FindWithTag("Player").GetComponent<Collider>() && _attacking == false){
				StartCoroutine(attacktimer());
				_attacking = true;
			} else if (Physics.Raycast(this.transform.position,Vector3.left,out left) && left.distance < range && left.collider == GameObject.FindWithTag("Player").GetComponent<Collider>() && _attacking == false ){
				StartCoroutine(attacktimer());
				_attacking = true;
			}
		}

		DuringUpdate();
	}

	public virtual void OnStart()
	{

	}

	public virtual void DuringUpdate()
	{

	}

	public virtual void Attack()
	{
		//every npc should be able to attack
		print("this is also here");
	}

	public IEnumerator attacktimer()
	{
		yield return new WaitForSeconds(attackCooldown);
		Attack();
		_attacking = false;
	}
}
