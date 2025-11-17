using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour

{
    private bool IsJump = false;
    Rigidbody2D rigid; // ������ٵ�
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public float jumpPower = 5.0f; //���� ��
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsJump)
        {
            audioSource.clip = jumpSound;
            audioSource.Play();
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        float xMove = Input.GetAxisRaw("Horizontal") * 3 * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, 0, 0));
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground" || collider.gameObject.tag == "bbbbb")
            IsJump = true;
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground" || collider.gameObject.tag == "bbbbb")
            IsJump = false;
    }

}
