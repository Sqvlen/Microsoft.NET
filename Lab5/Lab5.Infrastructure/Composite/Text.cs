using System.Text;

namespace Lab5.Infrastructure.Composite;

public class Text(string title) : Component
{
    private readonly List<Component> _components = new();

    public override string Operation()
    {
        var result = new StringBuilder();

        result.AppendLine($"TITLE \t{title}\t TITLE");
        
        foreach (var component in _components)
        {
            result.AppendLine("\t" + component.Operation());
        }
            
        return result + "\n";
    }

    public override void Add(Component component)
    {
        _components.Add(component);
    }

    public override void Remove(Component component)
    {
        _components.Remove(component);
    }

    public override bool IsComposite()
    {
        return true;
    }
}