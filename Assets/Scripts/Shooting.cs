using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;

    bool inFiringRange = true;
    bool isMeleeMode = false;
    bool lookingLeft = false;
    bool lookingRight = true;

    float centerAngle, minAngle, maxAngle;
    float currAngle;

    // Use this for initialization
    void Start()
    {
        centerAngle = 270.0f; // 270.0
        minAngle = centerAngle - 45.0f; //225.0
        maxAngle = centerAngle + 45.0f; //315.0
    }

    void LookAtCode()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = target - transform.position;
        transform.LookAt(transform.forward + transform.position, direction);
        inFiringRange = true;
    }
    // Update is called once per frame'

    void Update()
    {

        if (inFiringRange == true)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        else if (inFiringRange == false)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }

        float currAngleForward = transform.eulerAngles.z;
        float currAngleBackward = transform.eulerAngles.z;

        float originalX = transform.eulerAngles.x;
        float originalY = transform.eulerAngles.y;

        if (lookingRight == true)
        {
            centerAngle = 270.0f; // 270.0
            minAngle = centerAngle - 45.0f; //225.0
            maxAngle = centerAngle + 45.0f; //315.0

            if (currAngleForward > maxAngle)
            {
                inFiringRange = false;
                currAngleForward = maxAngle - 1f;
                transform.eulerAngles = new Vector3(originalX, originalY, currAngleForward);
            }
            else if (currAngleBackward < minAngle)
            {
                inFiringRange = false;
                currAngleBackward = minAngle + 1f;
                transform.eulerAngles = new Vector3(originalX, originalY, currAngleBackward);
            }
            else
            {
                LookAtCode();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                lookingLeft = true;
                lookingRight = false;
            }
        }

        else if (lookingLeft == true)
        {
            centerAngle = 90.0f; // 270.0
            minAngle = centerAngle - 45.0f; //225.0
            maxAngle = centerAngle + 45.0f; //315.0

            if (currAngleForward > maxAngle)
            {
                inFiringRange = false;
                currAngleForward = maxAngle - 1f;
                transform.eulerAngles = new Vector3(originalX, originalY, currAngleForward);
            }
            else if (currAngleBackward < minAngle)
            {
                inFiringRange = false;
                currAngleBackward = minAngle + 1f;
                transform.eulerAngles = new Vector3(originalX, originalY, currAngleBackward);
            }
            else
            {
                LookAtCode();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                lookingRight = true;
                lookingLeft = false;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mouseDirection.z = 0.0f;
            mouseDirection.Normalize();

            if (isMeleeMode == false)
            {
                if (inFiringRange == true)
                {
                    GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    newBullet.GetComponent<Bullet>().direction = mouseDirection;
                }

            }
        }

    }
}


//asd