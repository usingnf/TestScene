using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour, IInteractable
{
    private static int targetCount = 0; // 현재 게임에 존재하는 타겟 개수
    private bool isDead = false;

    [Header("Inspector")]
    [SerializeField] private Animator animator;

    private void Start()
    {
        Target.targetCount += 1;
    }

    public static int TargetCount()
    {
        return targetCount;
    }

    public void Interact()
    {
        if(isDead) 
            return;
        
        Remove();
    }

    private void OnMouseDown()
    {
        Interact();
    }

    private async void Remove()
    {
        isDead = true;
        GameManager.Instance.SubHp(10);
        animator.SetTrigger("disappear");
        EffectManager.Instance.Play(ParticleType.Destroy, this.transform.position, 5.0f);
        Target.targetCount += -1;
        if(GameManager.Instance.GetGameState() == GameState.Playing)
        {
            if (Target.targetCount <= 0)
            {
                UIManager.Instance.SetSystemMessage("Press \"E\"\nto respawn");
            }
        }

        await Task.Delay(800);
        if (this != null)
            Destroy(this.gameObject);
        
    }

}
