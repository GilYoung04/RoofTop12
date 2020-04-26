using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour
{
    public movement targetScript;

    // 유튜브를 보고 참고한 땅에 닿았는지 알려주는 센서 (중복 점프 방지를 위함)
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            targetScript.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.tag == "Ground")
        {
            targetScript.isGrounded = false;
        }
    }
}
