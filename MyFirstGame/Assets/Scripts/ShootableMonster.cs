﻿using UnityEngine;


public class ShootableMonster : Monster
{
    #region Fields
    [SerializeField] private float _rate = 2.0F;

    private Bullet _bullet;
    private Color _bulletColor = Color.red;
    #endregion


    #region UnityMethods
    protected override void Awake()
    {
        _bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating(nameof(Shoot), _rate, _rate);
    }
    #endregion


    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.2F;
        Bullet newBullet = Instantiate(_bullet, position, _bullet.transform.rotation) as Bullet;
        
        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.Color = _bulletColor;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        // этого монстра можно убить только прыгнув на него сверху
        // Mathf.Abs - модуль числа, если мы заходим слева при Х = -число, то модуль Х = +число
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit as Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5F)
                ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }
}