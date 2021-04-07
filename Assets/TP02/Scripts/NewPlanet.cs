using UnityEngine;

namespace planetScript
{
    public class NewPlanet : MonoBehaviour
    {
        private float oscillationSpeed;
        private float oscillationRadius;
        private float oscillationAngle;
        private float rotationSpeed;
        private MeshRenderer mesh;
        private Light lighting;
        private TrailRenderer trail;
        

        private float smooth = 5.0f;
        float tiltAroundY = 0.0f;

        private void Awake()
        {
            mesh = gameObject.GetComponent<MeshRenderer>();
        }

        public void Set(float _oscillationSpeed, float _oscillationRadius, float _oscillationAngle, float _rotationSpeed, Vector3 _scale, Material _material)
        {
            oscillationSpeed = _oscillationSpeed;
            oscillationRadius = _oscillationRadius;
            oscillationAngle = _oscillationAngle;
            rotationSpeed = _rotationSpeed;
            transform.localScale = _scale;
            mesh.material = _material;
        }

        public void SetLight()
        {
            lighting = gameObject.AddComponent<Light>();
            lighting.type = LightType.Point;
            lighting.intensity = 1.6f;
            lighting.range = UnityEngine.Random.Range(100f, 500f);
        }

        public void SetTrail()
        {
            trail = gameObject.AddComponent<TrailRenderer>();
        }

        void Update()
        {
            //======= Position

            Vector3 v3 = Vector3.zero;
            oscillationAngle += oscillationSpeed * Time.deltaTime;

            v3.x = oscillationRadius * Mathf.Cos(oscillationAngle);
            v3.z = oscillationRadius * Mathf.Sin(oscillationAngle);

            transform.localPosition = v3;

            //======= Rotation

            tiltAroundY += rotationSpeed * Time.deltaTime;
            Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

            transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        }
    }
}
