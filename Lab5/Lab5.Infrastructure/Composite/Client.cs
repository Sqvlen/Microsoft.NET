namespace Lab5.Infrastructure.Composite;

public class Client()
{
    public void Execute(Component component)
    {
        Console.WriteLine(component.IsComposite() ? component.Operation() : "The component can't be executed");
    }
}