using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private ParticleSystem ps;
    private int _moveSpeed = 4;
    private bool _grounded;
    private Rigidbody _rb;
    private Collider _collider;
    public int _weight;
    private int _scaleCounter = 0;
    private int _scaleLimit = 5;
    private RaycastHit _hit;

    public LayerMask _layerMask;

	public float health = 1;



	enum Rotation
    {
        Left = -1,
        Right = 1
    }

    private Rotation _rotation;

    public Transform _blob;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
		ps = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        AttackControls();
    }

    private void FixedUpdate()
    {
        JumpControls();
        _rb.velocity = new Vector3(0, _rb.velocity.y, _rb.velocity.z);
        MovementControls();
    }

    private void MovementControls()
    {
        //Movement);
        if (Input.GetKey(KeyCode.A))
        {
            _rb.velocity = new Vector3(-5f, _rb.velocity.y, _rb.velocity.z);
            _rotation = Rotation.Left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = new Vector3(5f, _rb.velocity.y, _rb.velocity.z);
            _rotation = Rotation.Right;
        }
    }

    private void JumpControls()
    {
        bool
            grounded = ((Physics.Raycast(transform.position, Vector3.down, _collider.bounds.extents.y + 0.2f)) || (Physics.Raycast(transform.position - new Vector3(_collider.bounds.extents.x,0,0), Vector3.down, _collider.bounds.extents.y + 0.2f)) || (Physics.Raycast(transform.position + new Vector3(_collider.bounds.extents.x,0,0), Vector3.down, _collider.bounds.extents.y + 0.2f)));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
				//_rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
				_rb.velocity = new Vector3(0,8,0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
    }

    private void AttackControls()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ScaleTheSlime();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ScaleTheSlime(false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Absorb();
        }
    }
    public void ScaleTheSlime(bool increase = true)
    {
        if (increase)
        {
            if (_scaleCounter < _scaleLimit)
            {
                transform.localScale *= 1.2f;
                _blob.localScale *= 1.2f;
                _scaleCounter++;
				health+=1;
				ps.Emit(20);
            }
        }
        else
        {
            if (_scaleCounter > 0)
            {
                transform.localScale /= 1.2f;
                _blob.localScale /= 1.2f;
				_scaleCounter--;
				health -=1;
				ps.Emit(20);
            }
        }
        _weight = _scaleCounter;
    }
    private void Attack()
    {
        Collider[] collisions = Physics.OverlapBox(transform.position + new Vector3(_collider.bounds.extents.x*2*(int)_rotation,0,0), _collider.bounds.extents, Quaternion.identity);
        
        foreach (Collider col in collisions)
        {
            if (col.CompareTag("Enemy"))
            {
                ScaleTheSlime();
            }
        }
    }
    private void Absorb()
    {
        Collider[] collisions = Physics.OverlapBox(transform.position, _collider.bounds.extents * 1.5f, Quaternion.identity,_layerMask);

        //for (int i = 0; i < collisions.Length; i++)
        //{
        //    ScaleTheSlime();
        //}

        foreach (Collider col in collisions)
        {
                ScaleTheSlime();
        }
    }

	public void TakeDamage()
    {
		ScaleTheSlime(false);
    }
}
