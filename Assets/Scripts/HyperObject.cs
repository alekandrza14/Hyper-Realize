using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class selectedHyperObject
{
    public static HyperObject ho;
}

public class HyperObject : MonoBehaviour
{

    [SerializeField] public Shape4D obj;
    [SerializeField] public HyperObject MainHyperObject;
  public  Color c = Color.white;

    private void Update()
    {
        MainHyperObject = selectedHyperObject.ho;
        if (selectedHyperObject.ho == this)
        {
            obj.colour = c - (Color.red / 5);
            if (Input.GetKey(KeyCode.Alpha1))
            {
                obj.transform.position -= new Vector3(Input.GetAxis("Mouse X"), 0, 0);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                obj.transform.position -= new Vector3(0, Input.GetAxis("Mouse X"), 0);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                obj.transform.position -= new Vector3(0, 0, Input.GetAxis("Mouse X"));
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                obj.positionW -= Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                obj.transform.localScale -= new Vector3(Input.GetAxis("Mouse X"), 0, 0);
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                obj.transform.localScale -= new Vector3(0, Input.GetAxis("Mouse X"), 0);
            }
            if (Input.GetKey(KeyCode.Alpha7))
            {
                obj.transform.localScale -= new Vector3(0, 0, Input.GetAxis("Mouse X"));
            }
            if (Input.GetKey(KeyCode.Alpha8))
            {
                obj.scaleW -= Input.GetAxis("Mouse X");
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
               c -= Color.red / 15;
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
               c += Color.red / 15;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                c -= Color.blue / 15;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                c += Color.blue / 15;
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                c -= Color.green / 15;
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                c += Color.green / 15;
            }
            if (Input.GetKey(KeyCode.F1))
            {
                obj.transform.Rotate(Input.GetAxis("Mouse X"), 0, 0);
            }
            if (Input.GetKey(KeyCode.F2))
            {
                obj.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            }
            if (Input.GetKey(KeyCode.F3))
            {
                obj.transform.Rotate(0, 0, Input.GetAxis("Mouse X"));
            }
            if (Input.GetKey(KeyCode.F4))
            {
                obj.rotationW.x -= Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.F5))
            {
                obj.rotationW.y -=  Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.F6))
            {
                obj.rotationW.z -=  Input.GetAxis("Mouse X");
            }

            if (Input.GetKey(KeyCode.Q))
            {
                obj.operation = Shape4D.Operation.Blend;
            }
            if (Input.GetKey(KeyCode.X))
            {
                obj.operation = Shape4D.Operation.Intersect;
            }
            if (Input.GetKey(KeyCode.Z))
            {
                obj.operation = Shape4D.Operation.Substract;
            }
            if (Input.GetKey(KeyCode.E))
            {
                obj.operation = Shape4D.Operation.Union;
            }
            if (Input.GetKey(KeyCode.Tab))
            {
                obj.smoothRadius -= Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.Delete))
            {
                gameObject.AddComponent<DELETE>();
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                gameObject.AddComponent<DELETE>();
            }
        }
      else  if (selectedHyperObject.ho != this)
        {
            obj.colour = c;
            
        }
    }

}
