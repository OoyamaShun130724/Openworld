using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody _rb;
    [SerializeField] public int _gold = 1000000;
    [SerializeField] GameObject _menuPannel;
    [SerializeField] public int _hp = 10;
    [SerializeField] public int _maxhp = 10;
    [SerializeField] float _jumpPower = 5;
    [SerializeField] string _groundTag = "Ground";
    [SerializeField] GameObject _inBattelUI;
    bool _isGrounded = false;
    public state _playerState;
    public bool _equipped;
    [SerializeField]public int _offencivePower;
    [SerializeField] public int _diffensivePower;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        switch(_playerState)
        {
            case state.Wandering:
                //WASD�̓��͂��󂯎��
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                Vector3 dir = Vector3.forward * v + Vector3.right * h;
                dir = Camera.main.transform.TransformDirection(dir);
                dir.y = 0;
                if (dir != Vector3.zero)
                {
                    this.transform.forward = dir;
                }
                _rb.velocity = dir.normalized * _moveSpeed
                 + _rb.velocity.y * Vector3.up;
                if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
                {
                    _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y + _jumpPower, _rb.velocity.z);
                    _isGrounded = false;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    OpenInventory();
                }
                break;

            case state.OpenMenu:

                _rb.velocity =  Vector3.zero;               
                break;
        }

    }
    public enum state
    {
        Wandering,
        OpenMenu,
        InBattle,
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _groundTag)
        {
            _isGrounded = true;
        }
    }
    private void OpenInventory()
    {
        _menuPannel.SetActive(true);
        _playerState = state.OpenMenu;      
    }
    public void ReceiveDamage(int value)
    {
        _hp -= value;
    }
}
