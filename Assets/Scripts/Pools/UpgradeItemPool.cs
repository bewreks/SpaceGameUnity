public class UpgradeItemPool : Pool
{
    public static Pool current;

    private void Awake()
    {
        current = this;
    }
}