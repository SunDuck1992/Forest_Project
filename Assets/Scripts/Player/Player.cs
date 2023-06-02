using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashPlayerAnimations))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _transitionRange;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRangeX;
    [SerializeField] private float _attackRangeY;
    [SerializeField] private float _attackRangeZ;
    [SerializeField] private LayerMask _layerEnemy;
    [SerializeField] private GameObject _canvas;

    private Rigidbody _rigidbody;
    private bool _isFaceRight = true;
    private bool _isGround;
    private Animator _animator;
    private int _currentHealth;
    private Enemy _enemy;
    private HashPlayerAnimations _hashPlayer;

    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _hashPlayer = GetComponent<HashPlayerAnimations>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();
        Attack();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int health)
    {
        _currentHealth += health;
        
        if(_currentHealth > _health)
        {
            _currentHealth = _health;
        }

        HealthChanged?.Invoke(_currentHealth, _health);
    }

    private void Move()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float zDirection = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xDirection, 0, zDirection);

        transform.Translate(movement * _speed * Time.deltaTime);

        if (xDirection != 0 || zDirection != 0)
        {
            _animator.SetBool(_hashPlayer.Run, true);
        }
        else
        {
            _animator.SetBool(_hashPlayer.Run, false);
        }

        if (xDirection > 0 && !_isFaceRight)
        {
            Flip();
        }

        if (xDirection < 0 && _isFaceRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
        }

        if (!_isGround)
        {
            _animator.SetBool(_hashPlayer.Jump, true);
        }
        else
        {
            _animator.SetBool(_hashPlayer.Jump, false);
        }
    }

    private void Attack()
    {
        if (HandleInput())
        {
            _animator.SetTrigger(_hashPlayer.Attack);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            _isGround = value;
        }
    }

    private void Flip()
    {
        _isFaceRight = !_isFaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Die()
    {
        DontDestroy obj = FindObjectOfType<DontDestroy>();
        obj.DestroyObject();
        Time.timeScale = 0;
        _canvas.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemy = null;
        }
    }

    private bool HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            return true;
        }

        return false;
    }

    private void PlayerAttack()
    {
        Collider[] enemiesToDamage = Physics.OverlapBox(_attackPosition.position, new Vector3(_attackRangeX, _attackRangeY, _attackRangeZ), Quaternion.identity, _layerEnemy);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_attackPosition.position, new Vector3(_attackRangeX, _attackRangeY, _attackRangeZ));
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger",CurrentHealth);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            _currentHealth = PlayerPrefs.GetInt("SavedInteger");
            HealthChanged?.Invoke(_currentHealth, _health);
        }
    }
}
