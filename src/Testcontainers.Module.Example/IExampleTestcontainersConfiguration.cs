namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Configurations;

  public interface IExampleTestcontainersConfiguration : ITestcontainersConfiguration
  {
    string Username { get; }

    string Password { get; }
  }
}
