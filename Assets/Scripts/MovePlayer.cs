using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Tooltip("Speed movement of the player")]
    [SerializeField] private float speed;

    [Tooltip("Add the hand of the player")]
    [SerializeField] private GameObject handRightTransform;

    [Tooltip("Add the hand of the player")]
    [SerializeField] private GameObject handLeftTransform;

    [SerializeField] private GameObject borderLeft;
    [SerializeField] private GameObject borderRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if(transform.position.x > borderRight.transform.position.x && move > 0)
        {
            move = 0;
        }
        else if(transform.position.x < borderLeft.transform.position.x && move < 0)
        {
            move = 0;
        }
        transform.position += new Vector3(move*Time.deltaTime*speed, 0, 0); // 1*1*3

        if(move < 0 && handRightTransform.activeSelf)
        {
            handLeftTransform.SetActive(true);
            handRightTransform.SetActive(false);
        }
        else if(move > 0 && !handRightTransform.activeSelf)
        {
            handLeftTransform.SetActive(false);
            handRightTransform.SetActive(true);
        }

        

    }
}
