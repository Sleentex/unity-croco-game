using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 4.0F;

    private SpriteRenderer sprite;
    private Vector3 direction;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        direction = transform.right;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            // Треба стрибати на монстра щоб убити
            /*if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.6F) // якщо сидіти біля краю то не убиває (БАГ) 0.76F
            {
                ReceiveDemage();           
            }
            else
            {
                unit.ReceiveDemage();
            }*/

            unit.ReceiveDemage(2);
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.6F, 0.01F);

        // colliders.All(x => !x.GetComponent<Character>()) - якщо ігрок, то не буде розвертатись
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>())) direction *= -1.0F;


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
