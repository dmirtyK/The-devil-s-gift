using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float speed = 1f;

    void Start()
    {
       // player = GameObject.Find("Skelet pon_3").transform; 
    }

    void Update()
    {
        Vector3 delta = player.position - GetComponent<Transform>().position;
        delta.Normalize();
        transform.Translate(delta * Time.deltaTime);
    }
}
