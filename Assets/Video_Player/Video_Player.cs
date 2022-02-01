using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Player : MonoBehaviour
{
    // to smoothly cut between two videos, we need two VideoPlayers
    // make sure you create two VideoPlayers and assign them in the Inspector
    public VideoPlayer activeCam, otherCam;
	private int stf;
	public GameObject uiExitCanvas;
    // edit this in the inspector, and fill it with your video clips
    public List<VideoClip> playlist = new List<VideoClip>();
	public List<GameObject> Shuttles = new List<GameObject>();
	private Dictionary<int,GameObject> ShuttlesMap = new Dictionary<int,GameObject>();
	private Dictionary<string,double> release_time_dict = new Dictionary<string,double>();
	public GameObject shuttle;

    // internal var, keeps track of whether there's another clip cued up
    VideoClip nextClip;
	private float Timer,delay;
    void Start()
    {
		
		stf =0;
        Shuffle(playlist, Shuttles);
	    for(int i=0;i<Shuttles.Count;i++)
			Shuttles[i].SetActive(false);
		
		//for(int i=0;i<Shuttles.Count;i++)
		//	Debug.Log(" " + playlist[i] + " " + Shuttles[i]);
		
		release_time_dict.Add("shot_1",1.29f);
		release_time_dict.Add("shot_2",1.24f);
		release_time_dict.Add("shot_3",1.30f);
		release_time_dict.Add("shot_4",1.51f);
		release_time_dict.Add("shot_5",1.52f);
		release_time_dict.Add("shot_6",1.72f);
		release_time_dict.Add("shot_7",1.15f);
		release_time_dict.Add("shot_8",1.24f);
		release_time_dict.Add("shot_9",1.38f);
		release_time_dict.Add("shot_10",1.37f);
		release_time_dict.Add("shot_11",1.72f);
		
		
        // play the first video in the playlist
        PrepareNextPlaylistClip();
        SwitchCams(activeCam);
		Timer=0.0f; 
		delay = 5.0f;
        // setup an event to automatically call SwitchCams() when we finish playing
        activeCam.loopPointReached += SwitchCams;
        otherCam.loopPointReached += SwitchCams;


		
    }

    void Update()
    {
		//Debug.Log("Update called " + Time.time);
			Timer += 1f * Time.deltaTime;
			//Debug.Log("current clip: " + activeCam.clip.name);
			//Debug.Log("shuttle; " + shuttle.name);
			
			if(activeCam.time >= release_time_dict[activeCam.clip.name] && activeCam.time < 3.5f && shuttle)
			{
				//Debug.Log("start:"+activeCam.time);
				shuttle.SetActive(true);
			}
			
	if (playlist.Count == 0 && activeCam.time >= activeCam.clip.length - 0.1 )
			    uiExitCanvas.SetActive(true);
			
			
				
		if(Timer >= delay)
		{
			Timer=0.0f;
			// when the current video is 0.1 seconds away from ending, prepare the next video clip on otherCam
			if (nextClip == null && activeCam.time >= activeCam.clip.length - 0.1)
			{
				//shuttle.SetActive(false);
				PrepareNextPlaylistClip();

				
			}
		
		}
		
		

    }
	
	

    // swaps the VideoPlayer references, so activeCam is always the active VideoPlayer
    void SwitchCams(VideoPlayer thisCam)
    {
        activeCam = otherCam;
        otherCam = thisCam;
        activeCam.targetCameraAlpha = 1f;
        otherCam.targetCameraAlpha = 0f;
		
        Debug.Log("new clip: " + nextClip.name);
        nextClip = null;
    }

    // cues up the next video clip in the playlist
    void PrepareNextPlaylistClip()
    {
        nextClip = playlist[0];
        otherCam.clip = nextClip;
        otherCam.Play();
        playlist.RemoveAt(0);
		shuttle = Shuttles[stf];
		stf++;
		}


    // randomize the video playlist
    static void Shuffle<T>(IList<T> playlist, List<GameObject> Shuttles)
    {
		GameObject stl;
        int n = playlist.Count;
        while (n >= 1)
        {
            n--;
            int k = Random.Range(0, n);
            T value = playlist[k];
			stl = Shuttles[k];
            playlist[k] = playlist[n];
			Shuttles[k] = Shuttles[n];
            playlist[n] = value;
			Shuttles[n] = stl;
			
        }
		
    }
	
	IEnumerator start_delay()
	{
		//Debug.Log("delaydelay " + Time.time);
		yield return new WaitForSeconds(10);
		yield return new WaitForSecondsRealtime(10f);
		//Debug.Log("exitdelaydelay "+Time.time);
	}
}