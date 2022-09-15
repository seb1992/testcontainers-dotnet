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

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity,TContainerEntity}" />
    public override TContainerEntity Build()
    {
      throw new System.NotImplementedException();
    }

    /// <inheritdoc cref="ICloneable{TBuilderEntity, IDockerResourceConfiguration}" />
    public override TestcontainersBuilder<TContainerEntity> Clone(IDockerResourceConfiguration dockerResourceConfiguration)
    {
      return this.Clone(new TestcontainersConfiguration(dockerResourceConfiguration));
    }

    /// <inheritdoc cref="ICloneable{TBuilderEntity, ITestcontainersConfiguration}" />
    public override TestcontainersBuilder<TContainerEntity> Clone(ITestcontainersConfiguration dockerResourceConfiguration)
    {
      return new TestcontainersBuilder<TContainerEntity>(new TestcontainersConfiguration(dockerResourceConfiguration, this.DockerResourceConfiguration));
    }
  }
}
