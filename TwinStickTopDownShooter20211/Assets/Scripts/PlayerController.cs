using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory = FactoryController;

public class PlayerController : Rigidbody2DBase
{
    public int Hp { get; protected set; }

    public GameObject bulletPrefab;

    private float speed = 2f;

    public float Horizontal { get; protected set; }
    public float Vertical { get; protected set; }
    public Vector3 MousePosition { get; protected set; }
    public bool Fire { get; protected set; }
    public bool Reload { get; protected set; }

    [SerializeField]
    private Vector3 diffAngle;

    [SerializeField]
    private int weaponIndex = 0;
    public int WeaponIndex 
    { 
        get { return weaponIndex; }
        protected set {
            if(weaponIndex != value)
            {
                CurrentWeapon.gameObject.SetActive(false);
                weaponIndex = value;
                CurrentWeapon.gameObject.SetActive(true);
            }
        }
    }
    public Weapon CurrentWeapon { get { return weapons[weaponIndex]; } }

    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();

    protected override void Awake()
    {
        base.Awake();

        weapons.AddRange(GetComponentsInChildren<Weapon>(true));
        CurrentWeapon.gameObject.SetActive(true);

    }
    public void SetInput(float horizontal, float vertical, Vector3 mousePosition, int selectWeapon, bool fire, bool reload)
    {
        Horizontal = horizontal;
        Vertical = vertical;
        MousePosition = mousePosition;
        WeaponIndex = (selectWeapon + weapons.Count) % weapons.Count;
        Fire = fire;
        Reload = reload;
    }

    private void Update()
    {
        if(Fire)
        {
            CurrentWeapon.Fire();

            //Vector3 rotation = bulletRespawn.rotation.eulerAngles;
            //Factory.GetObject("bullet", bulletRespawn.position, bulletRespawn.rotation);

            //Factory.GetObject("bullet", bulletRespawn.position, Quaternion.Euler(rotation.x,rotation.y,rotation.z - 10));

            //Factory.GetObject("bullet", bulletRespawn.position, Quaternion.Euler(rotation.x, rotation.y, rotation.z + 10));
        }

        if(Reload)
        {
            CurrentWeapon.Reload();
        }

        // Rotation
        diffAngle = MousePosition - tf.position;
        tf.rotation = Quaternion.Euler(0,0,Mathf.Atan2(diffAngle.y, diffAngle.x) * Mathf.Rad2Deg - 90f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal, Vertical) * speed;
    }
}
