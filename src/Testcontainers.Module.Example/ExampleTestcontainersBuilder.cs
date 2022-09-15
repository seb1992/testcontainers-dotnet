namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;

  public sealed class ExampleTestcontainersBuilder : TestcontainersBuilder<ExampleTestcontainersBuilder, IExampleTestcontainers, IExampleTestcontainersConfiguration>
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
      throw new System.NotImplementedException();
    }

    protected override ExampleTestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      throw new System.NotImplementedException();
    }

    protected override ExampleTestcontainersBuilder Clone(IExampleTestcontainersConfiguration dockerResourceConfiguration)
    {
      throw new System.NotImplementedException();
    }
  }
}
