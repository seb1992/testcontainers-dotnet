namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Configurations;

  /// <summary>
  /// TODO: ...
  /// </summary>
  public sealed class ExampleTestcontainersConfiguration : TestcontainersConfiguration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleTestcontainersConfiguration" /> class.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    public ExampleTestcontainersConfiguration(
      string username = null,
      string password = null)
    {
      this.Username = username;
      this.Password = password;
    }

    public ExampleTestcontainersConfiguration(ITestcontainersConfiguration dockerResourceConfiguration)
      : base(
        dockerResourceConfiguration.DockerEndpointAuthConfig,
        dockerResourceConfiguration.DockerRegistryAuthConfig,
        dockerResourceConfiguration.Image,
        dockerResourceConfiguration.Name,
        dockerResourceConfiguration.Hostname,
        dockerResourceConfiguration.WorkingDirectory,
        dockerResourceConfiguration.Entrypoint,
        dockerResourceConfiguration.Command,
        dockerResourceConfiguration.Environments,
        dockerResourceConfiguration.Labels,
        dockerResourceConfiguration.ExposedPorts,
        dockerResourceConfiguration.PortBindings,
        dockerResourceConfiguration.Mounts,
        dockerResourceConfiguration.Networks,
        dockerResourceConfiguration.NetworkAliases,
        dockerResourceConfiguration.OutputConsumer,
        dockerResourceConfiguration.WaitStrategies,
        dockerResourceConfiguration.ParameterModifiers,
        dockerResourceConfiguration.StartupCallback,
        dockerResourceConfiguration.AutoRemove,
        dockerResourceConfiguration.Privileged)
    {
    }

    /// <summary>
    /// Gets the username.
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password { get; }
  }
}
