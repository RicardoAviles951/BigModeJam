using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class AbilityManager : MonoBehaviour
{
    //Track the current ability
    AbilityBase currentAbility;
    public NeutralAbility neutralAbility        = new NeutralAbility();
    public InfluenceAbility InfluenceAbility    = new InfluenceAbility();
    public AngerAbility angerAbility            = new AngerAbility();
    public JoyAbility joyAbility                = new JoyAbility();
    private GameObject radius;

    //Reference to input system
    [HideInInspector] public StarterAssetsInputs input;
    //Color of affliction radius
    [HideInInspector] public Color color;
    //Reference to player transform for debug purposes
    private Transform self;
    private ParticleSystem particles;
    

    //Ability variables
    public float afflictionRadius = 0;
    public float maxRadius = 5;
    public float minRadius = 1;
    public float radiusGrowSpeed = 1f;
    public bool canAfflict = false;
   


    public LayerMask layer;
    [HideInInspector] public SphereCollider sphereCollider;
    [HideInInspector] public Detector detector;
    [HideInInspector] public VisManager visManager;
    private void Awake()
    {
        currentAbility = InfluenceAbility;
        detector = GetComponentInChildren<Detector>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        currentAbility.Activate(this);

        input          = GetComponent<StarterAssetsInputs>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        particles      = GetComponent<ParticleSystem>();
        radius         = GameObject.Find("VisualRadius");
        visManager     = GetComponentInChildren<VisManager>(); 
        self           = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentAbility.UpdateAbility(this);
        Afflict();
        visManager.color = color;
        if (input.restart)
        {
            RestartScene();
        }
    }

    public void ChangeAbility(AbilityBase ability)
    {
        currentAbility = ability;
        ability.Activate(this);
    }

    public void FixedUpdate()
    {
       
        
    }

    public void Afflict()
    {
        bool canGrow   = afflictionRadius < maxRadius;
        bool canShrink = afflictionRadius > minRadius;
        if (input.fire)
        {
            canAfflict = true;
            if (canGrow)
            {
                afflictionRadius += radiusGrowSpeed * Time.deltaTime;
            }
            else
            {
                afflictionRadius = maxRadius;
            }
            
        }
        else
        {
           canAfflict = false;
           afflictionRadius = minRadius;
        }
        //Vector3 scaleFactor = new Vector3(afflictionRadius, afflictionRadius, afflictionRadius);
        //radius.transform.localScale = scaleFactor*2f;
        sphereCollider.radius = afflictionRadius;
        visManager.radius = afflictionRadius;
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        if(self != null )
        {
            Gizmos.DrawWireSphere(self.position, afflictionRadius);
        }
        
    }

   public void Execute(AbilityManager ability, CrowdlingBrain crowdling)
    {
        if(canAfflict) 
        {
            currentAbility.SubscribedEvent(this, crowdling);
        }
             
    }

    public void RestartScene()
    {
        // Get the current active scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene again to restart it
        SceneManager.LoadScene(currentSceneName);
    }
}
