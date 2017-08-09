using UnityEngine;
using Firebase.Analytics;



public class analytics : MonoBehaviour
{
    GameManager gm;
    save sv;


    void Start()
    {


        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        sv = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<save>();
        ///dado > dadika
        InitializeFirebaseAndStart();
    }

    ///dadika > dadisa
    void InitializeFirebaseAndStart()
    {
        Firebase.DependencyStatus dependencyStatus = Firebase.FirebaseApp.CheckDependencies();

        if (dependencyStatus != Firebase.DependencyStatus.Available)
        {
            Firebase.FirebaseApp.FixDependenciesAsync().ContinueWith(task =>
            {
                dependencyStatus = Firebase.FirebaseApp.CheckDependencies();
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    InitializeFirebaseComponents();
                }
                else
                {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + dependencyStatus);
                    Application.Quit();
                }
            });
        }
        else
        {
            InitializeFirebaseComponents();
        }
    }


    //dadisa > analytics
    void InitializeFirebaseComponents()
    {
        InitializeAnalytics();

    }


    //analytics
    void InitializeAnalytics()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        // Set the user's sign up method.
        FirebaseAnalytics.SetUserProperty(
          FirebaseAnalytics.UserPropertySignUpMethod,
          "Google");

         // TODO(ccornell): replace this with a real user token
         // once Auth gets hooked up.
         // Set the user ID.
         FirebaseAnalytics.SetUserId("urer_from_hell");
    }


    void Update()
    {

        if (gm.gameActive && gm.pause)
        {
            FirebaseAnalytics.LogEvent(
            FirebaseAnalytics.EventPostScore,
            FirebaseAnalytics.ParameterScore, sv.analCheck);
        }
    }
}
