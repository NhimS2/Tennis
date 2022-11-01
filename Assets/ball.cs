using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class ball : MonoBehaviour
{
    public Vector3 batdau;
    public Vector3 huong;
    float luc = 9f;
    float t;

    
    // Start is called before the first frame update
    void Start()
    {
        batdau = transform.position;
        huong =new Vector3(0f,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        transform.position = PointPosition(t);
        float time2 = t + Time.deltaTime*2;
        Vector3 pos2 = PointPosition(time2);

        //Debug.DrawRay(transform.position, pos2-transform.position);

        RaycastHit hit;
        //Debug.Log(Vector3.Distance(transform.position, pos2));
        if (Physics.Raycast(transform.position, pos2 - transform.position, out hit , Vector3.Distance(pos2,transform.position)+0.5f))
        {
            t = 0;
            batdau = transform.position;
            Debug.Log(hit.collider.name);
            if (hit.collider.name == "tuong" || hit.collider.name == "player")
            {
                Debug.Log(huong);
                huong = Vector3.Reflect(huong, hit.normal);
                Debug.Log(huong);
            }
            else if (hit.collider.name == "die")
            {
                ResetTheGame();
            }
            else
            {

                Vector3.Reflect (huong, hit.normal);
            }
            //Debug.Log(Vector3.Distance(transform.position,pos2));
            
        }
    }
    Vector3 PointPosition(float t)
    {

        Vector3 position = batdau + ( huong * luc * t) + 0.5f * Physics.gravity * (t * t);
        return position;
    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("choi lai di !!");
    }
}
