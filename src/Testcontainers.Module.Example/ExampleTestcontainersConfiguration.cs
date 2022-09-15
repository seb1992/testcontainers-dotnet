namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Configurations;

  internal sealed class ExampleTestcontainersConfiguration : TestcontainersConfiguration, IExampleTestcontainersConfiguration
  {
    public ExampleTestcontainersConfiguration()
    {
    }

    public ExampleTestcontainersConfiguration(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration, dockerResourceConfiguration)
    {
    }

    public ExampleTestcontainersConfiguration(IExampleTestcontainersConfiguration next, IExampleTestcontainersConfiguration previous)
      : base(next, previous)
    {
      this.Username = next.Username ?? previous.Username;
      this.Password = next.Password ?? previous.Password;
    }

    public string Username { get; }

    public string Password { get; }
  }
}
