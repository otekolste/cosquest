
using UnityEngine;

public class shootingItem : MonoBehaviour
{
    public float speed;
    public int damage;
    private void Update(){
        transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            return;
        }
        if(collision.tag == "boss")
        {
            collision.GetComponent<BossHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if(collision.GetComponent<ShootingAction>()){
            collision.GetComponent<ShootingAction>().Action();
        }
    }
}
