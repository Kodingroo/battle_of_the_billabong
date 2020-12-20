using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIcon : MonoBehaviour
{
    public Sprite[] damageSprites;

    public float lifetime;

    public GameObject effect;

    private void Start() {
        //Invoke is the same as calling a function but allows you to add a waittime before execution.
        Invoke("Destruction", lifetime);
    }

    public void Setup(int damage){
        GetComponent<SpriteRenderer>().sprite = damageSprites[damage - 1];
    }

    void Destruction() {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
    }
}
