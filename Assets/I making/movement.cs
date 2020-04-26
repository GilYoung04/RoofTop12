using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public bool  isGrounded = false;

    // 얼마나 빠르게, 높이 할지 값을 설정할 수 있게 띄워논다.
    public float moveSpeed = 2f;
    public float jumpForce = 5f;

    void Update()
    {
        // A,D / ← , →  를 눌렀을 때 좌우로 이동하게 해준다. 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        // 점프
        if (Input.GetKeyDown(KeyCode.G) && isGrounded == true) // Trans: G키를 눌렀을때와 땅에 닿아있을때
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            isGrounded = false;
            Debug.Log("점프");
        }
    }
    
}
