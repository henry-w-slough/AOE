using UnityEngine;

public class FPS_Limiter : MonoBehaviour
{
    [SerializeField] int targetFPS;


    void Start()
    {
        Application.targetFrameRate = targetFPS;
    }
    void Update()
    {
        if (Application.targetFrameRate != targetFPS)
            Application.targetFrameRate = targetFPS;
    }
     
     
}

