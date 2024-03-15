using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected TextMeshPro healthGui;
    [SerializeField] GameObject deadEnemySkinPrefab;
    [SerializeField] bool isEnemyKilled = false;
    [SerializeField] bool isInCooldown = false;
    [SerializeField] protected int enemyHealthPoints = 5;
    [SerializeField] CharacterController player;
    [SerializeField] float knockback = -50f;
    [SerializeField] Animator animator;
    [SerializeField] Animation anim;
    [SerializeField] AudioClip takenDmgAudio;
    [SerializeField] AudioClip hadDiedAudio;
   // [SerializeField] string animatorLayerName = "Base Layer";
    // Start is called before the first frame update
    void Start()
    {
        healthGui.text = enemyHealthPoints.ToString();
    }

    [SerializeField] string weaponTag = "Weapon";
    [SerializeField] string rangedWeaponTag = "RWeapon";
    [SerializeField] string untaggedTag = "Untagged";
    [SerializeField] float hitCoolDownTime = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(weaponTag) )
        {
            Debug.Log("Weapon has wounded enemy");
            if (isInCooldown == true)
            {
                Debug.Log("hit but in cooldown, returning...");
                return;
            }

            //set a wounding knockback:
            Vector3 playerKnockback = new Vector3 (0, 0, knockback);
            playerKnockback = player.gameObject.GetComponent<Transform>().TransformDirection(playerKnockback);
            player.Move(playerKnockback * Time.deltaTime);

            ReduceHealth();
            var colliders = GetComponents<Collider>();
            colliders[0].enabled = false;
            this.StartCoroutine(CoolDown());

            PlayAudio(takenDmgAudio);
        }

        if (other.gameObject.CompareTag(rangedWeaponTag))
        {
            Debug.Log("RWeapon has wounded enemy");
            ReduceHealth();
            other.gameObject.tag = untaggedTag;
            PlayAudio(takenDmgAudio);
        
        }
    }
    public IEnumerator CoolDown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(hitCoolDownTime);
        var colliders = GetComponents<Collider>();
        colliders[0].enabled = true;
        isInCooldown = false;
    }

    private void ReduceHealth() 
    {
        enemyHealthPoints--;
        healthGui.text = enemyHealthPoints.ToString();
        if (enemyHealthPoints < 0)
            healthGui.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        //animator.Play(animatorLayerName+"."+ "enemy_w_sword_attack");
        if (enemyHealthPoints <= 0) 
        {
            KillEnemy();
        }    
    }
    public void KillEnemy() 
    {
        if (isEnemyKilled) return;

        /* foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }*/
        // Quaternion enemyDir = deadEnemySkinPrefab.transform.rotation;
        // enemyDir.eulerAngles 
        // = new Vector3( deadEnemySkinPrefab.transform.rotation.x,-this.transform.rotation.y,deadEnemySkinPrefab.transform.rotation.z);

        GameObject deadSkin = Instantiate(deadEnemySkinPrefab, this.transform.position, deadEnemySkinPrefab.transform.rotation); //, deadEnemySkinPrefab.transform.rotation);
        deadSkin.transform.rotation = this.transform.rotation;
        deadSkin.SetActive(true);
        isEnemyKilled = true;
        this.gameObject.SetActive(false);
    }




    public void WeaponDeflected() 
    {
        //animator.enabled = false;
        // TODO: make it so the attack animation would completely stop and all other animations
        animator.Play("Base Layer.enemy_w_sword_knockback");
        Vector3 playerKnockback = new Vector3 (0, 0, knockback);
        playerKnockback = player.gameObject.GetComponent<Transform>().TransformDirection(playerKnockback);
        player.Move(playerKnockback * Time.deltaTime);
    }
    public void RWeaponDeflected() 
    {
        //animator.enabled = false;
        // TODO: make it so the attack animation would completely stop and all other animations
        animator.Play("Base Layer.enemy_w_sword_knockback");
        //Vector3 playerKnockback = new Vector3 (0, 0, knockback);
        //playerKnockback = player.gameObject.GetComponent<Transform>().TransformDirection(playerKnockback);
        //player.Move(playerKnockback * Time.deltaTime);
    }


    public bool getIsEnemyKilled() { return isEnemyKilled; }
    public int getEnemyHP() { return enemyHealthPoints; }
    void PlayAudio(AudioClip ac) 
    {
            //playing wounding sound:
            AudioSource as1 = GetComponent<AudioSource>();
            as1.clip = ac;
            as1.Play();
    }
}
