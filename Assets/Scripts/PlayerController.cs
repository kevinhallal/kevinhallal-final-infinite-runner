using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] private float laneOffset = 2f;
    [SerializeField, Min(1)] private int laneCount = 3;
    [SerializeField] private float laneSwitchSpeed = 14f;

    [Header("Jump")]
    [SerializeField] private float jumpVelocity = 8f;
    [SerializeField] private float gravity = -25f;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance = 3f;
    [SerializeField] private float groundedOffset = 0.05f;

    private int _laneIndex;
    private float _y;
    private float _yVel;
    private Vector2 _prevMove;

    private bool _isGrounded;
    private float _groundY;

    void Awake()
    {
        if (TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 v = ctx.ReadValue<Vector2>();

        if (v.x > 0.5f && _prevMove.x <= 0.5f)
            ChangeLane(+1);
        else if (v.x < -0.5f && _prevMove.x >= -0.5f)
            ChangeLane(-1);

        if (v.y > 0.5f && _prevMove.y <= 0.5f && _isGrounded)
            _yVel = jumpVelocity;

        _prevMove = v;
    }

    private void ChangeLane(int delta)
    {
        int half = laneCount / 2;
        _laneIndex = Mathf.Clamp(_laneIndex + delta, -half, half);
    }

    void Update()
    {
        CheckGround();

        _yVel += gravity * Time.deltaTime;
        _y += _yVel * Time.deltaTime;

        if (_y <= _groundY)
        {
            _y = _groundY;
            _yVel = 0f;
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.MoveTowards(
            pos.x,
            _laneIndex * laneOffset,
            laneSwitchSpeed * Time.deltaTime
        );

        pos.y = _y + groundedOffset;
        pos.z = 0f;

        transform.position = pos;
    }

    private void CheckGround()
    {
        Vector3 rayStart = transform.position + Vector3.up * 0.5f;

        if (Physics.Raycast(
            rayStart,
            Vector3.down,
            out RaycastHit hit,
            groundCheckDistance,
            groundMask,
            QueryTriggerInteraction.Collide
        ))
        {
            _groundY = hit.point.y;
        }
        else
        {
            _groundY = 0f;
        }
    }
}