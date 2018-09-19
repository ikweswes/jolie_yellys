using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour {

	public float range;

	protected string _name;
	public float health = PlayerPrefs.GetInt("enemyHealth",0);
	protected float speed = 1;
	protected bool friendly = true;
	protected float attackCooldown = 1;
	protected float damageAbleToDeal = 1;
	protected RaycastHit right;
	protected RaycastHit left;
	protected PlayerScript player;
	protected bool iAmAttacking = false;
	protected Animator anim;

	bool _attacking = false;
	Rigidbody rigidboddy;


	void Start () {
		rigidboddy = GetComponent<Rigidbody>();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		OnStart();
		anim = this.GetComponentInChildren<Animator>();
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
		anim.SetBool("IsAttack",true);
		iAmAttacking = true;
		Attack();
		_attacking = false;
	}

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
