using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour, IDamage
{
    public CinemachineVirtualCamera _cvcam; // Cinemachineの仮想カメラへの参照
    Rigidbody _rb; // Rigidbodyコンポーネントへの参照
    bool _isGrounded = false; // プレイヤーが地面に接地しているかどうかのフラグ
    public state _playerState; // プレイヤーの現在の状態
    public bool _equipped; // プレイヤーが装備しているかどうかのフラグ
    public int _gold = 1000000; // プレイヤーの所持金
    public int _hp = 10; // プレイヤーの現在の体力
    public int _maxhp = 10; // プレイヤーの最大体力
    public int _offencivePower = 1; // プレイヤーの攻撃力
    public int _diffensivePower = 1; // プレイヤーの防御力
    public int _offenciveLimit = 30; // プレイヤーの攻撃上限
    public int _diffenciveLimit = 30; // プレイヤーの防御上限
    float _timer; // 攻撃の間隔を計測するタイマー
    public GameObject _gunPrefab;//銃のプレハブ
    [SerializeField] float _jumpPower = 5; // プレイヤーのジャンプ力
    [SerializeField] string _groundTag = "Ground"; // 地面を識別するためのタグ
    [SerializeField] Transform _respawnPos; // プレイヤーのリスポーン位置
    [SerializeField] float _shotRange = 20; // プレイヤーの射程距離
    [SerializeField] float _attackInterval = 0.2f; // 攻撃間隔
    [SerializeField] float _moveSpeed = 5f; // プレイヤーの移動速度
    [SerializeField] GameObject _menuPannel; // メニューパネルへの参照
    [SerializeField] GameObject _partcle; // パーティクルエフェクトへの参照
    [SerializeField] Transform _muzzlePos; // マズル位置
    

    void Start()
    {
        _gunPrefab.SetActive(false);
        _rb = GetComponent<Rigidbody>(); // プレイヤーオブジェクトにアタッチされたRigidbodyコンポーネントを取得する
        _cvcam = FindObjectOfType<CinemachineVirtualCamera>(); // シーン内からCinemachineの仮想カメラを見つける
    }

    private void Update()
    {
        _timer += Time.deltaTime; // 経過時間に基づいてタイマーを更新する
    }

    private void FixedUpdate()
    {
        switch (_playerState)
        {
            case state.Wandering:
                // WASDキーからの入力を受け取る
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                Vector3 dir = Vector3.forward * v + Vector3.right * h;
                dir = Camera.main.transform.TransformDirection(dir);
                dir.y = 0;
                if (dir != Vector3.zero)
                {
                    this.transform.forward = dir; // プレイヤーを移動方向に向ける
                }
                _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up; // プレイヤーに移動を適用する
                if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
                {
                    _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y + _jumpPower, _rb.velocity.z); // プレイヤーをジャンプさせる
                    _isGrounded = false;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    OpenInventory(); // インベントリを開く
                    _cvcam.enabled = false; // Cinemachineの仮想カメラを無効にする
                }
                Debug.DrawRay(this.transform.position + new Vector3(0, 0.5f, 0), this.transform.forward * _shotRange, Color.red);
                if (Input.GetButtonDown("Fire1") && _timer >= _attackInterval && _equipped)
                {
                    _timer = 0;
                    Instantiate(_partcle, _muzzlePos.position, Quaternion.identity); // マズル位置にパーティクルエフェクトを生成する
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit, _shotRange))
                    {
                        if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
                        {
                            enemy.ReceiveDamage(_offencivePower); // 敵にダメージを与える
                        }
                    }
                }
                break;
            case state.OpenMenu:
                _rb.velocity = Vector3.zero; // プレイヤーの移動を停止する
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
            _isGrounded = true; // 地面にTriggerが衝突した場合、接地フラグをtrueにする
        }
    }

    private void OpenInventory()
    {
        _menuPannel.SetActive(true); // メニューパネルをアクティブにする
        _playerState = state.OpenMenu; // プレイヤーの状態をOpenMenuに設定する
    }

    public void ReceiveDamage(int value)
    {
        int damage = Mathf.Max(value - _diffensivePower, 1); // 受けたダメージを計算する
        Debug.Log($"ダメージ{damage}");
        _hp -= damage; // プレイヤーの体力をダメージの量だけ減らす
        if (_hp < 0)
        {
            this.transform.position = _respawnPos.transform.position; // 体力がゼロになった場合、プレイヤーをリスポーン位置に移動させる
            _hp = _maxhp;
        }
    }
}
