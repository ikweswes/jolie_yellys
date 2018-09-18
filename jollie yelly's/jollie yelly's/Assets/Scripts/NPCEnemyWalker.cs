using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCEnemyWalker : NPCBase {


	ParticleSystem ps;
	Vector3 directionvector;
	bool iAmAttacking = false;
	ParticleCollisionEvent[] collisionEvents;

	public override void OnStart()
	{
		_name = "Walker";
		health = PlayerPrefs.GetInt("enemyHealth",0);
		friendly = false;
		attackCooldown = 3f;
		speed = 5;
		damageAbleToDeal = 1;
		ps = this.GetComponentInChildren<ParticleSystem>();
		ps.shape.rotation.Set(0,90,0);   
		collisionEvents = new ParticleCollisionEvent[8];
	}

	public override void DuringUpdate(){
		if(Physics.Raycast(this.transform.position,Vector3.right,out right)  && right.distance < 25 && right.collider == GameObject.FindWithTag("Player").GetComponent<Collider>() && iAmAttacking == false)
		{
			if(right.distance>2)
			{
			Vector3 newpos = new Vector3(speed*Time.deltaTime,0,0);
			gameObject.transform.Translate(Vector3.Lerp(transform.position,newpos,speed*0.2f));
			}
			ps.transform.localRotation = Quaternion.Euler(-20,90,0);
			directionvector = new Vector3(1,0,0)+transform.position;
		}
		else if (Physics.Raycast(this.transform.position,Vector3.left,out left) && left.distance <25 && left.collider == GameObject.FindWithTag("Player").GetComponent<Collider>() && iAmAttacking == false)
		{
			if(left.distance>2)
			{
			Vector3 newpos = new Vector3(-speed*Time.deltaTime,0,0);
			gameObject.transform.Translate(Vector3.Lerp(transform.position,newpos,speed*0.2f));
			}
			ps.transform.localRotation = Quaternion.Euler(-20,-90,0);
			directionvector = new Vector3(-1,0,0)+transform.position;
		}


	}


	public override void Attack()
	{
		iAmAttacking = true;
		StartCoroutine(attacktime());
		ps.Emit(20);

	}

	IEnumerator attacktime()
	{
		yield return new WaitForSeconds(0.3f);
		Collider[] collisions = Physics.OverlapBox(directionvector,new Vector3(1,1,1));
		foreach(Collider col in collisions)
		{
			if(col.gameObject.tag == "Player")
			{
				player.TakeDamage();
			}
		}
		yield return new WaitForSeconds(1);
		iAmAttacking = false;
	}



}
