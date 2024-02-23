using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] byte _maxHealth;
    [SerializeField] LevelInfoVisualizer levelEndPanel;
    private Camera _camera;
    public Action<int> OnHealthChanged;
    public Action<int> OnScoreChanged;
    public Axis axes; 
    private Rigidbody2D _rigidbody;

    private int _health = 3;
    public int Health {
        get => _health;
        private set { 
            _health = value;
            if (_health > _maxHealth) _health = _maxHealth;
            if (OnHealthChanged != null) OnHealthChanged.Invoke(_health);
        }
    }
    
    private int _score = 0;
    public int Score {
        get => _score;
        private set { 
            _score = value;
            if (OnScoreChanged != null) OnScoreChanged.Invoke(_score);
        }
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = _maxHealth;
        _camera = Camera.main;
    }

    void Update()
    {
        SetPlayerPosByVector3(GetFingerPosition());
    }

    Vector3 GetFingerPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit) && hit.collider != null)
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    void SetPlayerPosByVector3(Vector3 inputPos)
    {
        Vector3 newPosition = transform.position;
        if(axes == Axis.Vertical) {
            newPosition.y = inputPos.y;
        }else if (axes == Axis.Horizontal) {
            newPosition.x = inputPos.x;
        }else {
            newPosition = inputPos;
        }
        _rigidbody.MovePosition(newPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Respawn"))
        {
            GetComponent<AppNavigationTool>().ReLoadLevel();
        }
        else if (collision.gameObject.CompareTag("Skul"))
        {
            DealDamage();
        }else if (collision.gameObject.CompareTag("Coin"))
        {
            Score += 10;
        }else if (collision.gameObject.CompareTag("Finish"))
        {
            GameData.SetScoreByLevelID(SceneManager.GetActiveScene().buildIndex, _score);
            levelEndPanel.gameObject.SetActive(true);
            Destroy(this);
        }
    }

    void DealDamage()
    {   
        Health--;
        if(_health <= 0)
        {
            GetComponent<AppNavigationTool>().ReLoadLevel();
        }
    }
}