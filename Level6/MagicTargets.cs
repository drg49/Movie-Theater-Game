using UnityEngine;
using UnityEngine.AI;

public class MagicTargets : MonoBehaviour
{
    public NpcNavMesh magician;
    public Animator magicianAnim;
    public NavMeshAgent navMeshAgent;
    public GameObject magicTargetTwo;
    public GameObject knife;
    public AudioSource slashAudio;
    public GameObject npcNine;
    public GameObject magicTargOne;
    public GameObject bloodEffect;
    public GameObject bloodSplatter;
    public GameObject magicianDialogueEvent;

    private bool hasBeenCalled = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Magician")
        {
            magicTargetTwo.SetActive(true);
            magician.movePositionTransform = magicTargetTwo.GetComponent<Transform>();

            // Magician enters second target
            if (gameObject.name == magicTargetTwo.name && !hasBeenCalled)
            {
                hasBeenCalled = true;
                Destroy(magicTargOne);
                magicianAnim.SetTrigger("Idle");
                magician.enabled = false;
                navMeshAgent.enabled = false;
                knife.SetActive(true);
                magicianDialogueEvent.SetActive(true);
                Invoke("SlashAttack", 3.5f);
            }
        }
    }

    private void SlashAttack()
    {
        magicianAnim.SetTrigger("SlashAttack");
        npcNine.GetComponent<Animator>().SetTrigger("Dying");
        slashAudio.Play();
        npcNine.GetComponent<CapsuleCollider>().enabled = false;
        npcNine.GetComponent<RotateToTarget>().enabled = false;
        npcNine.GetComponent<MoveObjectTowards>().enabled = true;
        Invoke("ShowBlood", 0.2f);
        Invoke("ShowSplatter", 0.7f);
        Invoke("HideBlood", 1.5f);
    }

    private void ShowBlood()
    {
        bloodEffect.SetActive(true);
    }

    private void HideBlood()
    {
        bloodEffect.SetActive(false);
    }

    private void ShowSplatter()
    {
        bloodSplatter.SetActive(true);
    }
}
