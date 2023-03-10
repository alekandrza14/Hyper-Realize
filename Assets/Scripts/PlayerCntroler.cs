using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class command
{
    static public bool s;
}

public class PlayerCntroler : MonoBehaviour
{
    public RenderTexture rt1;
    public GameObject intput;
    public RenderTexture rt2;
    public RaymarchCam pos;
    public Camera c;
    public RawImage ri;
    IEnumerator Scrinshot()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        
        intput.SetActive(false);
        ri.texture = rt2;
        c.targetTexture = rt2;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.2f);

        ScreenCapture.CaptureScreenshot("C:/Unauticna Multiverse/Screenshot" + Random.Range(0, int.MaxValue) + ".png", 1);
        yield return new WaitForSeconds(0.2f);
        ri.texture = rt1;
        c.targetTexture = rt1;
        intput.SetActive(true);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
    void Update()
    {
        if (!selectedHyperObject.isloader)
        {

            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * 4);

            if (Input.GetKey(KeyCode.Return))
            {
                selectedHyperObject.ho = null;
            }
            if (Input.GetKey(KeyCode.C))
            {
                StartCoroutine(Scrinshot());
            }
            if (Input.GetKey(KeyCode.V))
            {
                transform.position += new Vector3(0, Input.GetAxis("Mouse X"), 0);
            }
            if (Input.GetKey(KeyCode.F))
            {
                pos._wPosition += Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.F7))
            {
                pos._wRotation.x += Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.F8))
            {
                pos._wRotation.y += Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.F9))
            {
                pos._wRotation.z += Input.GetAxis("Mouse X");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos._wRotation = Vector3.zero;
                pos._wPosition = 0;
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
