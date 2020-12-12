using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // Main CameraのTransform
    Transform tf;

    public GameObject targetObj;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = targetObj.transform.position;

        // Main CameraのTransformを取得する
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // カメラを左へ回転
            transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // カメラを右へ回転
            transform.Rotate(new Vector3(0f, 2.0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // カメラの回転をリセットする
            tf.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }
}
