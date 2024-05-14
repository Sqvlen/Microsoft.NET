using System.Text;

namespace Lab5.Infrastructure.Composite;

public class Word(string value) : Component
{
    public override string Operation()
    {
        return value;
    }

    public override bool IsComposite()
    {
        return true;
    }
}