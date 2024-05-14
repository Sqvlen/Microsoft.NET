using System.Text;

namespace Lab5.Infrastructure.Composite;

public class Paragraph : Component
{
    private readonly List<Component> _children = new();
    
    public override string Operation()
    {
        var result = new StringBuilder();

        foreach (var child in _children)
        {
            result.AppendLine(child.Operation() + ".");
        }
        
        return result.ToString();
    }
    
    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override bool IsComposite()
    {
        return true;
    }
}