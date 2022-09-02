namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Containers;
  using Microsoft.Extensions.Logging;

  /// <summary>
  /// TODO: ...
  /// </summary>
  internal sealed class ExampleTestcontainers : TestcontainersContainer, IExampleTestcontainers
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleTestcontainers" /> class.
    /// </summary>
    /// <param name="configuration">The Testcontainers configuration.</param>
    /// <param name="logger">The logger.</param>
    public ExampleTestcontainers(ExampleTestcontainersConfiguration configuration, ILogger logger)
      : base(configuration, logger)
    {
      this.Username = configuration.Username;
      this.Password = configuration.Password;
    }

    /// <inheritdoc />
    public string Username { get; }

    /// <inheritdoc />
    public string Password { get; }
  }
}
