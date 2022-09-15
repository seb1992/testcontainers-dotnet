namespace DotNet.Testcontainers.Builders
{
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="TestcontainersBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
  [PublicAPI]
  public sealed class TestcontainersBuilder : TestcontainersBuilder<TestcontainersBuilder, ITestcontainersContainer, ITestcontainersConfiguration>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersBuilder" /> class.
    /// </summary>
    public TestcontainersBuilder()
      : this(new TestcontainersConfiguration())
    {
    }

    private TestcontainersBuilder(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    public override ITestcontainersContainer Build()
    {
      throw new System.NotImplementedException();
    }

    protected override TestcontainersBuilder Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      throw new System.NotImplementedException();
    }

    protected override TestcontainersBuilder Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      throw new System.NotImplementedException();
    }
  }
}
