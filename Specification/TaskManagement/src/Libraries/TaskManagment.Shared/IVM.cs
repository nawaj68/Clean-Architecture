namespace TaskManagement.Shared;

public interface IVM<T>
    where T : IEquatable<T>
{
    T Id { get; set; }
}

public interface IVM : IVM<int>
{

}

public class VM : VM<int> { }

public class VM<T> : IVM<T>
      where T : IEquatable<T>
{
    public required T Id { get; set; }
}