using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Enemy : MonoBehaviour
{
    public float CurrentSpeed { get; private set; }

    [SerializeField] private float _runSpeed = 2f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _animationSpeed = 1f;

    private Rigidbody _rigidBody;
    private CapsuleCollider _capsuleCollider;
    private Animator _animator;

    private bool isRun = false;
    private Vector3 _lastPosition;

    public void TakeDamage()
    {
        SetActiveRagdoll(true);
        _animator.enabled = false;
        _rigidBody.isKinematic = true;
        _capsuleCollider.enabled = false;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();

        SetActiveRagdoll(false);
    }

    private void FixedUpdate()
    {
        CurrentSpeed = (_rigidBody.position - _lastPosition).magnitude;
        _lastPosition = _rigidBody.position;

        Vector3 moveDirection = (Camera.main.transform.position - transform.position).normalized;

        isRun = moveDirection != Vector3.zero;

        _rigidBody.velocity = new Vector3(moveDirection.x * _runSpeed, _rigidBody.velocity.y, moveDirection.z * _runSpeed);
        _rigidBody.angularVelocity = Vector3.zero;

        if (isRun)
        {
            Quaternion rotationTarget = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            _rigidBody.rotation = Quaternion.Lerp(_rigidBody.rotation, rotationTarget, Time.fixedDeltaTime * _rotationSpeed);
        }

        _animator.SetBool("IsRun", isRun);
        _animator.SetFloat("AnimSpeed", _animationSpeed * moveDirection.magnitude);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }

    private void SetActiveRagdoll(bool value)
    {
        foreach (var rb in GetComponentsInChildren<Rigidbody>())
        {
            if (rb != _rigidBody)
            {
                rb.GetComponent<Collider>().enabled = value;
                rb.isKinematic = !value;
            }
        }
    }

}
