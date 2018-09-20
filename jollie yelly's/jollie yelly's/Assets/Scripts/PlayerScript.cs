using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public AudioClip jump;
	public AudioClip Atack;
	public AudioClip fall;
	public AudioClip getdamage;
	public AudioClip eat;
    public AudioClip death;
    public AudioClip candy;

	private AudioSource os;

	private ParticleSystem ps;
    private int _moveSpeed = 4;
    private bool _grounded;
    private Rigidbody _rb;
    private Collider _collider;
    public int _weight;
    private int _scaleCounter = 0;
    private int _scaleLimit = 5;
    private RaycastHit _hit;
    private bool pressed = false;

    public LayerMask layerMask;
    public Canvas deathScreen;
    public Canvas UI;
    public Text _uiText;
    public GameObject[] _uiHealthParts;
    public Animator animator;
    public GameObject model;

	public float health = 1;
    public int collectibles = 0;



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
		os = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        AttackControls();
        for (int i = 0; i < health-1; i++)
        {
            _uiHealthParts[i].SetActive(false);
        }
        for (int i = 4; i > health-2; i--)
        {
            if (i >= 0)
            {
                _uiHealthParts[i].SetActive(true);
            }
        }
        if (health <= 0)
        {
            Die();
        }
        _uiText.text = collectibles.ToString() + " x";
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
            Vector3 EuRot = transform.rotation.eulerAngles;
            EuRot.y = -90f;
            model.transform.rotation = Quaternion.Euler(EuRot);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = new Vector3(5f, _rb.velocity.y, _rb.velocity.z);
            _rotation = Rotation.Right;
            Vector3 EuRot = transform.rotation.eulerAngles;
            EuRot.y = 90f;
            model.transform.rotation = Quaternion.Euler(EuRot);
        }
    }

    private void JumpControls()
    {
        bool
            grounded = ((Physics.Raycast(transform.position, Vector3.down, _collider.bounds.extents.y + 0.2f)) || (Physics.Raycast(transform.position - new Vector3(_collider.bounds.extents.x,0,0), Vector3.down, _collider.bounds.extents.y + 0.2f)) || (Physics.Raycast(transform.position + new Vector3(_collider.bounds.extents.x,0,0), Vector3.down, _collider.bounds.extents.y + 0.2f)));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded && !pressed)
            {
                pressed = true;
                animator.SetBool("IsJump", true);
                StartCoroutine(Jumpy());
                os.PlayOneShot(jump);
            }
        }
    }

    private IEnumerator Jumpy()
    {
        yield return new WaitForSeconds(0.2f);
        _rb.velocity = new Vector3(0, 8, 0);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("IsJump", false);
        pressed = false;
    }

    private void AttackControls()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ScaleTheSlime();
            collectibles++;

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ScaleTheSlime(false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Absorb();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Die();
        }
    }
    public void ScaleTheSlime(bool increase = true)
    {
        if (increase)
        {
            if (_scaleCounter < _scaleLimit)
            {
				os.PlayOneShot(eat);
                transform.localScale *= 1.2f;
                _blob.localScale *= 1.2f;
                _scaleCounter++;
				health++;
				ps.Emit(20);
            }
        }
        else
        {
			os.PlayOneShot(getdamage);
            if (_scaleCounter > 0)
            {
                transform.localScale /= 1.2f;
                _blob.localScale /= 1.2f;
				_scaleCounter--;
				ps.Emit(20);
            }
            health--;
        }
        _weight = _scaleCounter;
    }
    private void Attack()
    {
        Collider[] collisions = Physics.OverlapBox(transform.position + new Vector3(_collider.bounds.extents.x*2*(int)_rotation,0,0), _collider.bounds.extents, Quaternion.identity);
        animator.SetBool("IsAttack", true);
        StartCoroutine(Tacky());
        
        foreach (Collider col in collisions)
        {
            if (col.CompareTag("Enemy"))
            {
				os.PlayOneShot(Atack);
                col.GetComponent<NPCEnemyWalker>().health--;
            }
        }
    }

    private IEnumerator Tacky()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsAttack", false);
    }

    private void Absorb()
    {
        Collider[] collisions = Physics.OverlapBox(transform.position, _collider.bounds.extents * 1.5f, Quaternion.identity,layerMask);

        foreach (Collider col in collisions)
        {
            if (col.CompareTag("Enemy"))
            {
                NPCEnemyWalker script = col.GetComponent<NPCEnemyWalker>();
                if (script.health <= 0)
                {
                    ScaleTheSlime();
                    script.Die();
                    PlayerAlignmentManager.AddPoints(PlayerAlignmentManager.PlayerType.KILLER, 1);
                }
            }
        }
    }

	public void TakeDamage()
    {
		ScaleTheSlime(false);
    }

    public void Die()
    {
        StartCoroutine(Deathy());
        os.PlayOneShot(death);
    }

    private IEnumerator Deathy()
    {
        yield return new WaitForSeconds(0.5f);
        transform.parent.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(true);
    }

    public void PlayCandy()
    {
        os.PlayOneShot(candy);
    }
}
