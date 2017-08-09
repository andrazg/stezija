using UnityEngine;
using Firebase.Analytics;

public class save : MonoBehaviour
{

    GameManager gm;
    public TextMesh score;
    public TextMesh check;
    public TextMesh timesPl;
    public TextMesh about;
    public GameObject checkpoint;

    int level;


   public int analCheck;


    string abut = @"Synesthesia is a gift where cognitive pathways
in our brains are provoked and linked with other
sensory pathways.With such ability in ones mind
numbers, words, characters and even single notes
of music get connected with colors.People with
such condition can organize and memorize patterns
much more than the ones without it. The ability
supposedly emerges when children first engage in 
solving abstract concepts.
This game intentionaly puts you in an uncomfortable 
position where cerebral pathways are constantly 
provoked trying to unlock your brain to achieve the 
yet unthinkable.";

	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }
    void Update ()
    {
        
        level = PlayerPrefs.GetInt("level");
        score.text = "Round reached: " + (PlayerPrefs.GetInt("level"));
        check.text = "Checkpoint: " + PlayerPrefs.GetInt("checkpoint").ToString();
        timesPl.text = "Times played: " + PlayerPrefs.GetInt("times").ToString();

        if (gm.round > level)
        {
            PlayerPrefs.SetInt("level", gm.round);

            //analytics for the max level reached
            new Parameter(FirebaseAnalytics.EventLevelUp, gm.round);
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp, new Parameter(FirebaseAnalytics.ParameterLevel, gm.round));
            
        }
        if (gm.round % 50 == 0 && gm.round > 1)
        {
            PlayerPrefs.SetInt("checkpoint", gm.round);
            analCheck = PlayerPrefs.GetInt("checkpoint"); ;
        }
        
        if (gm.score == true)
        {
            about.text = abut;
            about.fontSize = 80;
        }
        else if(gm.score == false)
        {
            about.text = "";
            about.fontSize =1;
        }



    }
}
