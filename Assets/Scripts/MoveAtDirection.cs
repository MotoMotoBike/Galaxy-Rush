
using UnityEngine;

public class MoveAtDirection : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] float lifeTime;
    float _currentLifeTime;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        MovePosition();
    }

    void Update()
    {
    }

    void MovePosition()
    {
        _rigidbody.velocity = direction;
    }
}
