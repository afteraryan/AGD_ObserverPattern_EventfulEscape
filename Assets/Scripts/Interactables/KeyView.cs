using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        int keys = GameService.Instance.GetPlayerController().KeysEquipped;
        GameService.Instance.GetInstructionView().HideInstruction();
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);
        
        keys++;
        EventService.Instance.OnKeyPickedUp.InvokeEvent(keys);

        gameObject.SetActive(false);
    }
}
