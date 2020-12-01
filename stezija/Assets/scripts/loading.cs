using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    public Material cube;

    public GameObject cube1;
    public GameObject die;
    public GameObject cubedestr;
    public GameObject loader;
    public GameObject dieload;
    public GameObject loaddestr;

    AudioSource au;


    //public Renderer rend;
    AsyncOperation async;
    bool instant;



	void Start ()
    {
        async = SceneManager.LoadSceneAsync("main");
        async.allowSceneActivation = false;
        instant = true;
        au = GetComponent<AudioSource>();
    }

	void Update ()
    {
        if (async.progress == 0.9f)
        {
            StartCoroutine(Loader());
        }
        
	}


    IEnumerator Loader()
    {
      yield return new WaitForSeconds(2);
      DestroyObject(die);
        DestroyObject(dieload);
        if (instant)
        {
            au.Play();
            GameObject cubedestr1 = Instantiate(cubedestr, cubedestr.transform.position, cubedestr.transform.rotation);
            GameObject loaddestr1 = Instantiate(loaddestr, loaddestr.transform.position, loaddestr.transform.rotation);
            Destroy(cubedestr1, 1);
            Destroy(loaddestr1, 1);
            instant = false;
        }
       yield return new WaitForSeconds(2);
        async.allowSceneActivation = true;
        



    }


}
