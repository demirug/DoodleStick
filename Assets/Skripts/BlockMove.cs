using UnityEngine;
using UnityEngine.UI;

public class BlockMove : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        float spd = (speed + (((int)ObjectSpawner.aliveTime() / 5 / 100.0f)));

        if (spd > 0.23) spd = 0.23f;

        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x - spd, this.gameObject.transform.position.y);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }


}
