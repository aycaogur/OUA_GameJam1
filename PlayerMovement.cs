using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed, runSpeed;

    private Animator _playerAnimator;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;

    private Vector2 _movementInput;
    private Vector3 _currentMovement;

    private bool _isMoving, _isRuning;

    private void Awake()
    {
        SetMotionEvents();
    }
    private void Start()
    {
        GetPlayerComponents();
    }
    private void FixedUpdate()
    {
        GetPlayerMovement();
        SetPlayerFlipX();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();

        _currentMovement.x = _movementInput.x;
        _currentMovement.y = _movementInput.y;

        _isMoving = _movementInput.x != 0 || _movementInput.y != 0;

        _playerAnimator.SetBool("IsMove", _isMoving);
    }
    private void OnRun(InputAction.CallbackContext context)
    {
        _isRuning = context.ReadValueAsButton();

        _playerAnimator.SetBool("IsRuning", _isRuning);
    }
    private void GetPlayerMovement()
    {
        if (!_isRuning) _rigidBody2D.MovePosition(transform.position + _currentMovement.normalized * walkSpeed * Time.deltaTime);
        else _rigidBody2D.MovePosition(transform.position + _currentMovement.normalized * runSpeed * Time.deltaTime);
    }
    private void GetPlayerComponents()
    {
        _playerAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void SetPlayerFlipX()
    {
        if (_currentMovement.x < 0) _spriteRenderer.flipX = true;
        else if (_currentMovement.x > 0) _spriteRenderer.flipX = false;
    }
    private void SetMotionEvents()
    {
        _playerInput = new PlayerInput();

        _playerInput.PlayerController.Movement.started += OnMove;
        _playerInput.PlayerController.Movement.performed += OnMove;
        _playerInput.PlayerController.Movement.canceled += OnMove;

        _playerInput.PlayerController.Run.started += OnRun;
        _playerInput.PlayerController.Run.performed += OnRun;
        _playerInput.PlayerController.Run.canceled += OnRun;
    }
    private void OnEnable()
    {
        _playerInput.PlayerController.Enable();
    }
    private void OnDisable()
    {
        _playerInput.PlayerController.Disable();
    }
}