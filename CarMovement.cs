using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public Animator animator;
    public float speed = 5f;

    private SpriteRenderer _spriteRenderer;
    private int _currentWaypointIndex = 0;
    private bool _movingForward = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (_currentWaypointIndex >= waypoints.Length || _currentWaypointIndex < 0)
        {
            _currentWaypointIndex = 0;
        }

        Vector3 targetPosition = waypoints[_currentWaypointIndex].position;
        Vector3 currentPosition = transform.position;

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        bool movingInPositiveXDirection = transform.position.x > currentPosition.x;
        bool movingInNegativeXDirection = transform.position.x < currentPosition.x;
        bool movingInPositiveYDirection = transform.position.y > currentPosition.y;
        bool movingInNegativeYDirection = transform.position.y < currentPosition.y;

        if (transform.position == targetPosition)
        {
            if (_currentWaypointIndex == waypoints.Length - 1)
            {
                _movingForward = false;
            }
            else if (_currentWaypointIndex == 0)
            {
                _movingForward = true;
            }

            _currentWaypointIndex += _movingForward ? 1 : -1;
        }
        if (movingInPositiveXDirection)
        {
            animator.SetBool("Horizontal", true);
            animator.SetBool("Vertical", false);

            _spriteRenderer.flipX = false;
        }
        else if (movingInNegativeXDirection)
        {
            _spriteRenderer.flipX = true;
            _spriteRenderer.flipY = false;
            animator.SetBool("Horizontal", true);
            animator.SetBool("Vertical", false);
        }
        else if (movingInPositiveYDirection)
        {
            animator.SetBool("Horizontal", false);
            animator.SetBool("Vertical", true);
            _spriteRenderer.flipY = false;
        }
        else if (movingInNegativeYDirection)
        {
            animator.SetBool("Horizontal", false);
            animator.SetBool("Vertical", true);
            _spriteRenderer.flipY = true;
        }
    }
}
