using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class ShootableMonster : Monster
{
    [SerializeField]
    private float rate = 2.0F; // частота стрельби
    [SerializeField]
    private Color bulletColor = Color.white;

    private Bullet bullet;
    private SpriteRenderer sprite;

    protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate); // 
    }

    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += 0.7F;

        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        int direction = sprite.flipX != false ? 1 : -1;
        
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * direction; // щоб вліво дивився (треба зробити і вправа!!!)
        newBullet.Color = bulletColor;
        

    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            // Треба стрибати на монстра щоб убити
            /*if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.76F) // якщо сидіти біля краю то не убиває (БАГ)
            {
                ReceiveDemage();
            }
            else
            {
                unit.ReceiveDemage();
            }*/

            unit.ReceiveDemage(3);
        }
    }
}
