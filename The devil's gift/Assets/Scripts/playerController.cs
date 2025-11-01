using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Transform hit;

    private bool lookRight;

    public int health;

    public float speed; // скорость перемещения
    public float moveInputH; // переменная отвечающая за вычисление направления перемещения по горизонтали
    public float moveInputV; // переменная отвечающая за вычисление направления перемещения по виртикали
   
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // получаем компонент Rigidbody2D
    }


    void Update()
    {

    }
    void FixedUpdate()
    {
        moveInputH = Input.GetAxis("Horizontal"); // присваеваем систему инпутов встроенных в юнити по горизонтали
        moveInputV = Input.GetAxis("Vertical"); // присваеваем систему инпутов встроенных в юнити по виртикали
        rb.linearVelocity = new Vector2(moveInputV * speed, rb.linearVelocity.y); // перемещение в заданную сторону (moveInputV) помноженное на скорость (speed) в заданном векторе времени (rb.linearVelocity.y) (y напровление вектора (вертикальное))
        rb.linearVelocity = new Vector2(moveInputH * speed, rb.linearVelocity.x); // перемещение в заданную сторону (moveInputH) помноженное на скорость (speed) в заданном векторе времени (rb.linearVelocity.x) (x напровление вектора (горизонтальное))

        if (lookRight == true && moveInputH > 0) // условия поворота 
        {
            FlipIt();
        }
        else if (lookRight == false && moveInputH < 0)
        {
            FlipIt();
        }
    }

    private void FlipIt() // поворот спрайта 
    {
        lookRight = !lookRight; 
        Vector3 Scaler = transform.localScale; 
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnMouseDown()
    {
        Instantiate(hit, transform.position, transform.rotation);
       
    }
}
