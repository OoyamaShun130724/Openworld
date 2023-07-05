using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour, IDamage
{
    public CinemachineVirtualCamera _cvcam; // Cinemachine�̉��z�J�����ւ̎Q��
    Rigidbody _rb; // Rigidbody�R���|�[�l���g�ւ̎Q��
    bool _isGrounded = false; // �v���C���[���n�ʂɐڒn���Ă��邩�ǂ����̃t���O
    public state _playerState; // �v���C���[�̌��݂̏��
    public bool _equipped; // �v���C���[���������Ă��邩�ǂ����̃t���O
    public int _gold = 1000000; // �v���C���[�̏�����
    public int _hp = 10; // �v���C���[�̌��݂̗̑�
    public int _maxhp = 10; // �v���C���[�̍ő�̗�
    public int _offencivePower = 1; // �v���C���[�̍U����
    public int _diffensivePower = 1; // �v���C���[�̖h���
    public int _offenciveLimit = 30; // �v���C���[�̍U�����
    public int _diffenciveLimit = 30; // �v���C���[�̖h����
    float _timer; // �U���̊Ԋu���v������^�C�}�[
    public GameObject _gunPrefab;//�e�̃v���n�u
    [SerializeField] float _jumpPower = 5; // �v���C���[�̃W�����v��
    [SerializeField] string _groundTag = "Ground"; // �n�ʂ����ʂ��邽�߂̃^�O
    [SerializeField] Transform _respawnPos; // �v���C���[�̃��X�|�[���ʒu
    [SerializeField] float _shotRange = 20; // �v���C���[�̎˒�����
    [SerializeField] float _attackInterval = 0.2f; // �U���Ԋu
    [SerializeField] float _moveSpeed = 5f; // �v���C���[�̈ړ����x
    [SerializeField] GameObject _menuPannel; // ���j���[�p�l���ւ̎Q��
    [SerializeField] GameObject _partcle; // �p�[�e�B�N���G�t�F�N�g�ւ̎Q��
    [SerializeField] Transform _muzzlePos; // �}�Y���ʒu
    

    void Start()
    {
        _gunPrefab.SetActive(false);
        _rb = GetComponent<Rigidbody>(); // �v���C���[�I�u�W�F�N�g�ɃA�^�b�`���ꂽRigidbody�R���|�[�l���g���擾����
        _cvcam = FindObjectOfType<CinemachineVirtualCamera>(); // �V�[��������Cinemachine�̉��z�J������������
    }

    private void Update()
    {
        _timer += Time.deltaTime; // �o�ߎ��ԂɊ�Â��ă^�C�}�[���X�V����
    }

    private void FixedUpdate()
    {
        switch (_playerState)
        {
            case state.Wandering:
                // WASD�L�[����̓��͂��󂯎��
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                Vector3 dir = Vector3.forward * v + Vector3.right * h;
                dir = Camera.main.transform.TransformDirection(dir);
                dir.y = 0;
                if (dir != Vector3.zero)
                {
                    this.transform.forward = dir; // �v���C���[���ړ������Ɍ�����
                }
                _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up; // �v���C���[�Ɉړ���K�p����
                if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
                {
                    _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y + _jumpPower, _rb.velocity.z); // �v���C���[���W�����v������
                    _isGrounded = false;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    OpenInventory(); // �C���x���g�����J��
                    _cvcam.enabled = false; // Cinemachine�̉��z�J�����𖳌��ɂ���
                }
                Debug.DrawRay(this.transform.position + new Vector3(0, 0.5f, 0), this.transform.forward * _shotRange, Color.red);
                if (Input.GetButtonDown("Fire1") && _timer >= _attackInterval && _equipped)
                {
                    _timer = 0;
                    Instantiate(_partcle, _muzzlePos.position, Quaternion.identity); // �}�Y���ʒu�Ƀp�[�e�B�N���G�t�F�N�g�𐶐�����
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, _shotRange))
                    {
                        if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
                        {
                            enemy.ReceiveDamage(_offencivePower); // �G�Ƀ_���[�W��^����
                        }
                    }
                }
                break;
            case state.OpenMenu:
                _rb.velocity = Vector3.zero; // �v���C���[�̈ړ����~����
                break;
        }

    }

    public enum state
    {
        Wandering,
        OpenMenu,
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _groundTag)
        {
            _isGrounded = true; // �n�ʂ�Trigger���Փ˂����ꍇ�A�ڒn�t���O��true�ɂ���
        }
    }

    private void OpenInventory()
    {
        _menuPannel.SetActive(true); // ���j���[�p�l�����A�N�e�B�u�ɂ���
        _playerState = state.OpenMenu; // �v���C���[�̏�Ԃ�OpenMenu�ɐݒ肷��
    }

    public void ReceiveDamage(int value)
    {
        int damage = Mathf.Max(value - _diffensivePower, 1); // �󂯂��_���[�W���v�Z����
        Debug.Log($"�_���[�W{damage}");
        _hp -= damage; // �v���C���[�̗̑͂��_���[�W�̗ʂ������炷
        if (_hp < 0)
        {
            this.transform.position = _respawnPos.transform.position; // �̗͂��[���ɂȂ����ꍇ�A�v���C���[�����X�|�[���ʒu�Ɉړ�������
            _hp = _maxhp;
        }
    }
}
