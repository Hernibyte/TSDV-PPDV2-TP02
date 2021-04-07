using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed = 5;
    public float radius = 2;
    public float angle = 0;

    private float smooth = 5.0f;
    public float rotationSpeed;
    float tiltAroundY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //======= Position

        Vector3 v3 = Vector3.zero;
        angle += speed * Time.deltaTime;

        v3.x = radius * Mathf.Cos(angle);
        v3.z = radius * Mathf.Sin(angle);

        transform.localPosition = v3;

        //======= Rotation

        tiltAroundY += rotationSpeed * Time.deltaTime;
        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}