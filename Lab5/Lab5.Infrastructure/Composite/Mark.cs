namespace Lab5.Infrastructure.Composite;

public class Mark(string value) : Component
{
    public override string Operation()
    {
        return value;
    }

    public override bool IsComposite()
    {
        return false;
    }
}