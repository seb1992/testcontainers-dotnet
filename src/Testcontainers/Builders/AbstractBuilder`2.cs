namespace DotNet.Testcontainers.Builders
{
  using System;
  using System.Collections.Generic;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <summary>
  /// An abstract fluent Docker resource builder.
  /// </summary>
  /// <typeparam name="TBuilderEntity">The builder entity.</typeparam>
  /// <typeparam name="TResourceEntity">The resource entity.</typeparam>
  /// <typeparam name="TConfigurationEntity">The configuration entity.</typeparam>
  public abstract class AbstractBuilder<TBuilderEntity, TResourceEntity, TConfigurationEntity> : IAbstractBuilder<TBuilderEntity, TResourceEntity>
    where TConfigurationEntity : IDockerResourceConfiguration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AbstractBuilder{TBuilderEntity, TConfigurationEntity, TContainerEntity}" /> class.
    /// </summary>
    /// <param name="dockerResourceConfiguration">The Docker resource configuration.</param>
    protected AbstractBuilder(TConfigurationEntity dockerResourceConfiguration)
    {
      this.DockerResourceConfiguration = dockerResourceConfiguration;
    }

    /// <summary>
    /// Gets the Docker resource configuration.
    /// </summary>
    protected TConfigurationEntity DockerResourceConfiguration { get; }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public virtual TBuilderEntity WithDockerEndpoint(string endpoint)
    {
      return this.WithDockerEndpoint(new Uri(endpoint));
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public virtual TBuilderEntity WithDockerEndpoint(Uri endpoint)
    {
      return this.WithDockerEndpoint(new DockerEndpointAuthenticationConfiguration(endpoint));
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public virtual TBuilderEntity WithDockerEndpoint(IDockerEndpointAuthenticationConfiguration dockerEndpointAuthConfig)
    {
      return this.Clone(new DockerResourceConfiguration(dockerEndpointAuthenticationConfiguration: dockerEndpointAuthConfig));
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public virtual TBuilderEntity WithCleanUp(bool cleanUp)
    {
      return this.WithResourceReaperSessionId(TestcontainersSettings.ResourceReaperEnabled && cleanUp ? ResourceReaper.DefaultSessionId : Guid.Empty);
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public virtual TBuilderEntity WithLabel(string name, string value)
    {
      var labels = new Dictionary<string, string> { { name, value } };
      return this.Clone(new DockerResourceConfiguration(labels: labels));
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public virtual TBuilderEntity WithResourceReaperSessionId(Guid resourceReaperSessionId)
    {
      return this.WithLabel(ResourceReaper.ResourceReaperSessionLabel, resourceReaperSessionId.ToString("D"));
    }

    /// <inheritdoc cref="IAbstractBuilder{TBuilderEntity, TContainerEntity}" />
    public abstract TResourceEntity Build();

    /// <summary>
    /// Clones the Docker resource builder configuration.
    /// </summary>
    /// <param name="dockerResourceConfiguration">The Docker resource configuration.</param>
    /// <returns>A configured instance of <typeparamref name="TBuilderEntity" />.</returns>
    [PublicAPI]
    protected abstract TBuilderEntity Clone(IDockerResourceConfiguration dockerResourceConfiguration);

    /// <summary>
    /// Clones the Docker resource builder configuration.
    /// </summary>
    /// <param name="dockerResourceConfiguration">The Docker resource configuration.</param>
    /// <returns>A configured instance of <typeparamref name="TBuilderEntity" />.</returns>
    [PublicAPI]
    protected abstract TBuilderEntity Clone(TConfigurationEntity dockerResourceConfiguration);
  }
}
