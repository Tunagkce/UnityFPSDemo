using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public float waitBeforeSearch = 8f;
    private float shotTimer;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if(shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > waitBeforeSearch)
            {
                //search state
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public void Shoot()
    {
        //store reference to the gun barrel.
        Transform gunbarrel = enemy.gunBarrel;
        //instantiate a new bullet.
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
        //calculate the direction to the player.
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        //add force to the rigidbody of the bullet.
        bullet.GetComponent<Rigidbody>().linearVelocity = Quaternion.AngleAxis(Random.Range(-3f,3f), Vector3.up) * shootDirection * 40;
        shotTimer = 0;
    }


}
