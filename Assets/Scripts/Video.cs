using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject canvas;
    public GameObject[] objectsToDeactivate;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playVideo() 
    {
        canvas.SetActive(true);
        video.Play();
        foreach (GameObject element in objectsToDeactivate)
        {
            element.transform.position = element.transform.position + new Vector3(0,100,0);

        }
        audio.Pause();
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
     {
         float videoLength = (float)video.GetComponent<UnityEngine.Video.VideoPlayer>().length;
 
         yield return new WaitForSeconds(videoLength);

        canvas.SetActive(false);
        foreach (GameObject element in objectsToDeactivate)
        {
            element.transform.position = element.transform.position + new Vector3(0,-100,0);
        }
        audio.Play();
         
     }
}
