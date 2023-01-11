using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private float minRange;

    [SerializeField]
    private float maxRange;

    [SerializeField]
    private GameObject Collectable;

    [SerializeField]
    Text CollectableCountDisplay;

    [SerializeField]
    Text timeDisplay;

    public static int CollectableCount;

    private float time;

    [SerializeField]
    private float maxTime;


    void Start ()
    {
        SpawnCollectable();
    }


    // Collectable Spawnt bei Start
   


    void Update ()
    {
        // Timer kann über Delta Time (unabhängig von der FrameRate) erstellt werden
        time += Time.deltaTime;

        // Wenn die Zeit abgelaufen ist, soll das Spiel von vorne beginnen
        if(time >= maxTime)
        {
            SceneManager.LoadScene(0);
            CollectableCount = 0;
        }

        // Timer und Score werden jeden Frame aktualisiert und angezeigt
        timeDisplay.text = Mathf.Round(maxTime - time).ToString() + " sec. left"; ;
        CollectableCountDisplay.text = "Score: " + CollectableCount.ToString();
    }

    //durch diese Funktion (random range) wird das Collectable random gespawnt
    public void SpawnCollectable()
    {
        
        Instantiate(Collectable, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
