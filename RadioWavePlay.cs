using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class RadioWavePlay : MonoBehaviour {

    public int chargeTarget = 100;
    public RaycastHit hit;
	public Material green;
	public Material red;
	public AudioSource sound;
    public ParticleSystem radioWave, radioWave2;
    public float time;
    public float stopRF;

    private int nextLevel;
    private LineRenderer lr;

    // Use this for initialization
    public void Start () {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        lr = GetComponent<LineRenderer>();
		lr.material = green;
    }
	
	// Update is called once per frame
	public void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene(0);
        }
        if(time >= stopRF)
        {
            radioWave.Stop();
            radioWave.Clear();
            radioWave2.Stop();
            radioWave2.Clear();
        }
        lr.SetPosition(0, transform.position);
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider)
                {

                    lr.SetPosition(1, hit.point);
                    IsItTarget();
                    //radioWave.transform.position = hit.point;
                }
            }
            else
            {
				lr.material = red;
				sound.Stop ();
                lr.SetPosition(1, transform.forward * 5000);
                radioWave2.Stop();
                radioWave.Stop();
            }           
	}

    public void IsItTarget()
    {
        if(hit.collider.tag == "target")
        {
            lr.material = green;
            if (!radioWave.isPlaying)
            {
                radioWave.Play();
                //Debug.Log("Radiowave: " + radioWave.isPlaying);
            }
            if (!radioWave2.isPlaying)
            {
                radioWave2.Play();
            }         
            //Time.timeScale = 0.25f;
            if (!sound.isPlaying)
            {
                sound.Play ();
            }
            //SceneManager.LoadScene(nextLevel);
        } 
    }
}