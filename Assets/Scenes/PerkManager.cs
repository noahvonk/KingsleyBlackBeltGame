using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PerkManager : MonoBehaviour
{
    public static PerkManager Instance;

    [Header("Civilization Chosen")]
    public bool China = false;
    public bool Germany = false;
    public bool Japan = false;
    public bool France = false;
    public bool Britain = false;


    [Header("MarchSP")]
    public bool MarchSPActive = false;

    //[SerializeField] private float MarchSpeed = 1.0f;
    
    [SerializeField] private float MarchSpeedMulti = 2f;

    //[Header("SkillDMG")]
    //public bool SkillDMGActive = false;

    //[SerializeField] private float SkillDamage = 1.0f;
    
    //[SerializeField] private float SkillDamageMulti = 1.5f;

    [Header("DMGBuff")]
    //[SerializeField] private float BaseDamage = 1.0f;

    public bool ArcherDMGActive = false;
    
    //public bool KnightDMGActive = false;

    public bool WarriorDMGActive = false;
    
    [SerializeField] private float ArcherDamageMulti = 2f;

    [SerializeField] private float WarriorDamageMulti = 2f;

    //[SerializeField] private float KnightDamageMulti = 1.5f;

    [Header("FarmSP")]
    public bool FarmSPActive = false;

    [SerializeField] private float FarmSpeed = 1.0f;
    
    [SerializeField] private float FarmSpeedMulti = 2f;

   // [Header("AttackSP")]
   // public bool AttackSPActive = false;

   // [SerializeField] private float AttackSpeed = 1.0f;
    
    //[SerializeField] private float AttackSpeedMulti = 1.5f;

    [Header("WallHP")]
    public bool WallHPActive = false;

    [SerializeField] private float WallHealth = 1.0f;
    
    [SerializeField] private float WallHealthMulti = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
