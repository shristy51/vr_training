using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Player : MonoBehaviour
{
    // to smoothly cut between two videos, we need two VideoPlayers
    // make sure you create two VideoPlayers and assign them in the Inspector
    public VideoPlayer activeCam, otherCam;

    // edit this in the inspector, and fill it with your video clips
    public List<VideoClip> playlist = new List<VideoClip>();
	public List<GameObject> Shuttles = new List<GameObject>();
	private Dictionary<string,GameObject> ShuttlesMap = new Dictionary<string,GameObject>();
	private Dictionary<string,double> release_time_dict = new Dictionary<string,double>();
	public GameObject shuttle;

    // internal var, keeps track of whether there's another clip cued up
    VideoClip nextClip;
	private bool Timer;
    void Start()
    {
        Shuffle(playlist);
        // play the first video in the playlist
        PrepareNextPlaylistClip();
        SwitchCams(activeCam);
		Timer=false; 
        // setup an event to automatically call SwitchCams() when we finish playing
        activeCam.loopPointReached += SwitchCams;
        otherCam.loopPointReached += SwitchCams;
		shuttle.SetActive(false);
		release_time_dict.Add("shot_1",1.0f);
		release_time_dict.Add("shot_2",1.0f);
		release_time_dict.Add("shot_3",1.0f);
		release_time_dict.Add("shot_4",1.0f);
		release_time_dict.Add("shot_5",1.0f);
		release_time_dict.Add("shot_6",1.0f);
		release_time_dict.Add("shot_7",1.0f);
		release_time_dict.Add("shot_8",1.0f);
		release_time_dict.Add("shot_9",1.0f);
		release_time_dict.Add("shot_10",1.0f);
		
		ShuttlesMap.Add("shot_1",Shuttles[0]);
		ShuttlesMap.Add("shot_2",Shuttles[1]);
		ShuttlesMap.Add("shot_3",Shuttles[2]);
		ShuttlesMap.Add("shot_4",Shuttles[3]);
		ShuttlesMap.Add("shot_5",Shuttles[4]);
		ShuttlesMap.Add("shot_6",Shuttles[5]);
		ShuttlesMap.Add("shot_7",Shuttles[6]);
		ShuttlesMap.Add("shot_8",Shuttles[7]);
		ShuttlesMap.Add("shot_9",Shuttles[8]);
		ShuttlesMap.Add("shot_10",Shuttles[9]);
		
    }

    void Update()
    {
		if (playlist.Count == 0)
				return;
		if(!Timer)
		{
			
			StartCoroutine(CountDown(5));
			// when the current video is 0.1 seconds away from ending, prepare the next video clip on otherCam
			if (nextClip == null && activeCam.time >= activeCam.clip.length - 0.1)
			{
				PrepareNextPlaylistClip();
				shuttle.SetActive(false);
			}
		
			if(activeCam.time >= 1.0f && activeCam.time <= 2.95f)
			{
				Debug.Log("start:"+activeCam.time);
				shuttle.SetActive(true);
			}
			else
			//if(activeCam.time >= 2.95f || activeCam.time <= 1.0f)
			{
				Debug.Log("end:"+activeCam.time);
				shuttle.SetActive(false);
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
    }


	//delay couroutine
	IEnumerator CountDown(float delay)
	{
		Timer = true;
		yield return new WaitForSeconds(delay);
		Timer= false;
	}
    // randomize the video playlist
    public static void Shuffle<T>(IList<T> playlist)
    {
        int n = playlist.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            T value = playlist[k];
            playlist[k] = playlist[n];
            playlist[n] = value;
        }
    }
}