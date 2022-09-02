namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Configurations;

  public class ExampleTestcontainersBuilder :
    TestcontainersBuilder<ExampleTestcontainersBuilder, ExampleTestcontainersConfiguration, IExampleTestcontainers>
  {
    public ExampleTestcontainersBuilder()
      : base(new ExampleTestcontainersConfiguration())
    {
    }

    public ExampleTestcontainersBuilder WithUsername(string username)
    {
      return this.MergeNewConfiguration(new ExampleTestcontainersConfiguration(username: username));
    }

    public ExampleTestcontainersBuilder WithPassword(string password)
    {
      return this.MergeNewConfiguration(new ExampleTestcontainersConfiguration(password: password));
    }

    public override IExampleTestcontainers Build()
    {
      return new ExampleTestcontainers(this.DockerResourceConfiguration, TestcontainersSettings.Logger);
    }

    protected override ExampleTestcontainersBuilder MergeNewConfiguration(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      return this.MergeNewConfiguration(new TestcontainersConfiguration(dockerResourceConfiguration));
    }

    protected override ExampleTestcontainersBuilder MergeNewConfiguration(ExampleTestcontainersConfiguration dockerResourceConfiguration)
    {
      return new ExampleTestcontainersBuilder(); // TODO: Merge configurations.
    }
  }
}
