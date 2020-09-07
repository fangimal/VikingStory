using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBtwAttack; //перезарядка


    public float startTimeBtwAttack;
    public Transform attackPos; //Позиция атаки
    public LayerMask enemy; //Слой который будет получать урон
    public float attackRange; //Радиус атаки
    public int damage;
    public Animator anim;

    AudioSource audiosound;

    private void Start()
    {
        audiosound = GetComponent<AudioSource>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }


    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    OnAttackButtonDown();
        //}
        timeBtwAttack -= Time.deltaTime;
    }
    public void OnAttackButtonDown()
    {
        if (timeBtwAttack <= 0)
        {
            anim.SetTrigger("AttackTrigger");
            audiosound.Play();
            timeBtwAttack = startTimeBtwAttack;
        }
        //else
        //{
        //    timeBtwAttack -= Time.deltaTime;
        //}
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage); //Урон наносится элементу содержащий скрипт Enemy
        }
    }
}
