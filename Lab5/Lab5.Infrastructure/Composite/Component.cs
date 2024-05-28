namespace Lab5.Infrastructure.Composite;

public abstract class Component
{
    public abstract string Operation();

    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }

    public abstract bool IsComposite();
}