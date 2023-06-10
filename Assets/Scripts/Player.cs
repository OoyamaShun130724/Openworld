using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody _rb;
    [SerializeField] public int _gold = 1000000;
    [SerializeField] GameObject _menuPannel;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //WASD‚Ì“ü—Í‚ðŽó‚¯Žæ‚é
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _menuPannel.SetActive(true);
        }
    }
}
