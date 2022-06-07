using UnityEngine;

public class HandgunControls : MonoBehaviour
{
    public Animator handgunAnim;
    public Animator pistolAnim;
    public GameObject defaultCircle;
    public GameObject pistolCrosshair;
    public bool gunIsOut = false;
    private bool disableFirstFire = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !PauseMenu.GameIsPaused)
        {
            if (gunIsOut)
            {
                PutGunAway();
            }
            else if (!gunIsOut)
            {
                PullOutGun();
            }
        }
        if (Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused)
        {
            if (disableFirstFire)
            {
                disableFirstFire = false;
            }
            else if (gunIsOut && !disableFirstFire)
            {
                pistolAnim.SetBool("Fire", true);
            }
        }
    }

    public void PullOutGun()
    {
        handgunAnim.SetTrigger("PullOut");
        defaultCircle.SetActive(false);
        pistolCrosshair.SetActive(true);
        gunIsOut = true;
    }

    public void PutGunAway()
    {
        handgunAnim.SetTrigger("PutAway");
        pistolCrosshair.SetActive(false);
        defaultCircle.SetActive(true);
        gunIsOut = false;
    }
}
