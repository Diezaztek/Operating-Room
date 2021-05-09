using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject canvas;
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
        StartCoroutine(LateCall());
        video.Play();
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
     {
         float videoLenght = (float)video.GetComponent<UnityEngine.Video.VideoPlayer>().length;
 
         yield return new WaitForSeconds(videoLenght);
 
         canvas.SetActive(false);
     }
}
