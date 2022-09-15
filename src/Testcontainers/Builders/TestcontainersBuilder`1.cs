namespace DotNet.Testcontainers.Builders
{
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <inheritdoc cref="TestcontainersBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />
  [PublicAPI]
  public sealed class TestcontainersBuilder<TContainerEntity> : TestcontainersBuilder<TestcontainersBuilder<TContainerEntity>, TContainerEntity, ITestcontainersConfiguration>
    where TContainerEntity : ITestcontainersContainer
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersBuilder{TContainerEntity}" /> class.
    /// </summary>
    public TestcontainersBuilder()
      : this(new TestcontainersConfiguration())
    {
    }

    private TestcontainersBuilder(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    /// <inheritdoc />
    public override TContainerEntity Build()
    {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc />
    protected override TestcontainersBuilder<TContainerEntity> Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc />
    protected override TestcontainersBuilder<TContainerEntity> Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      throw new System.NotImplementedException();
    }
  }
}
