
using UnityEngine;

public class shootingItem : MonoBehaviour
{
    public float speed;
    private void Update(){
        transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            return;
        }
        if(collision.GetComponent<ShootingAction>()){
            collision.GetComponent<ShootingAction>().Action();
        }
    }
}
