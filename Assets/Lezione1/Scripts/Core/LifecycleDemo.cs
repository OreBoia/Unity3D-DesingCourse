using UnityEngine;

namespace DES.U1.Basics
{
    public class LifecycleDemo : MonoBehaviour
    {
        [Header("ID settings (examples of field visibility)")]
        [SerializeField] private int id = 0;                 // private + serialized -> visible in Inspector
        public string label = "Actor";                       // public -> visible & editable in Inspector
        [HideInInspector] public int runtimeClicks = 0;      // public but hidden in Inspector

        [Header("References")]
        [SerializeField] private Renderer targetRenderer;    // drag the MeshRenderer here in the Prefab

        [Header("Appearance")]
        [SerializeField] private Color baseColor = Color.cyan;
        [SerializeField] private float emission = 0f;

        void Reset()
        {
            // Called when the component is first added. Try to auto-fill references.
            if (targetRenderer == null) targetRenderer = GetComponentInChildren<Renderer>();
        }

        void Awake()
        {
            Debug.Log($"[LifecycleDemo] Awake  | {name} (id={id}, label={label})");
        }

        void OnEnable()
        {
            Debug.Log($"[LifecycleDemo] Enable | {name}");
        }

        void Start()
        {
            Debug.Log($"[LifecycleDemo] Start  | {name}");
            ApplyAppearance();
        }

        void Update()
        {
            // Just as a visible runtime variable we can click to change color
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                runtimeClicks++;
                float t = Mathf.PingPong(runtimeClicks * 0.2f, 1f);
                SetColor(Color.Lerp(baseColor, Color.white, t));
                Debug.Log($"[LifecycleDemo] Clicks={runtimeClicks} on {name}");
            }
        }

        void OnDisable()
        {
            Debug.Log($"[LifecycleDemo] Disable| {name}");
        }

        void OnDestroy()
        {
            Debug.Log($"[LifecycleDemo] Destroy| {name}");
        }

        public void SetID(int newId) { id = newId; }
        public void SetLabel(string newLabel) { label = newLabel; }

        public void SetColor(Color c)
        {
            baseColor = c;
            ApplyAppearance();
        }

        private void ApplyAppearance()
        {
            if (targetRenderer == null) return;
            var mat = targetRenderer.sharedMaterial;
            if (mat == null) return;

            // Works with default URP/Lit or Standard material
            if (mat.HasProperty("_BaseColor")) mat.SetColor("_BaseColor", baseColor);
            if (mat.HasProperty("_Color")) mat.SetColor("_Color", baseColor);
            if (mat.HasProperty("_EmissionColor"))
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", baseColor * emission);
            }
        }
    }
}
