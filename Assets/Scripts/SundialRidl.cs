using UnityEngine;

public class SundialRidl : MonoBehaviour
{
    private float raylength=150f;
    [SerializeField] public GameObject horse;
    [SerializeField] public Transform Sundial;

    private bool HasInstantiated=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detection();
    }
    private void detection(){
        if (Physics.Raycast(Sundial.position,Sundial.forward,out RaycastHit hit,raylength))

        {
            if (hit.collider.CompareTag("time") && !HasInstantiated)
            {
                Instantiate(horse,new Vector3(0,1.2f,0),Quaternion.identity);
                Debug.Log("target got hit");
                HasInstantiated=true;
            }
        }
        Debug.DrawRay(Sundial.position, Sundial.forward * raylength, Color.red);
    }

}
