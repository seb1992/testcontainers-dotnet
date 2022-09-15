namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  [PublicAPI]
  public interface IExampleTestcontainers : ITestcontainersContainer
  {
    [PublicAPI]
    string Username { get; }

    [PublicAPI]
    string Password { get; }
  }
}
