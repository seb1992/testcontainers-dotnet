namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;

  public sealed class ExampleTestcontainersBuilder : TestcontainersBuilder<ExampleTestcontainersBuilder, IExampleTestcontainers, IExampleTestcontainersConfiguration>, ICloneable<ExampleTestcontainersBuilder, IExampleTestcontainersConfiguration>
  {
    public ExampleTestcontainersBuilder()
      : base(new ExampleTestcontainersConfiguration())
    {
    }

    private ExampleTestcontainersBuilder(IExampleTestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public override IExampleTestcontainers Build()
    {
      return new ExampleTestcontainers(this.DockerResourceConfiguration, TestcontainersSettings.Logger);
    }

    public override ExampleTestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      return this.Clone(new TestcontainersConfiguration(dockerResourceConfiguration));
    }

    public override ExampleTestcontainersBuilder Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      return this.Clone(new ExampleTestcontainersConfiguration(dockerResourceConfiguration));
    }

    public ExampleTestcontainersBuilder Clone(IExampleTestcontainersConfiguration dockerResourceConfiguration)
    {
      return new ExampleTestcontainersBuilder(new ExampleTestcontainersConfiguration(dockerResourceConfiguration, this.DockerResourceConfiguration));
    }
  }
}
