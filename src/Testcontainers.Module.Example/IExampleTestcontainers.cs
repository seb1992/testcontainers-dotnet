namespace Testcontainers.Module.Example
{
  using DotNet.Testcontainers.Containers;
  using JetBrains.Annotations;

  /// <summary>
  /// TODO: ...
  /// </summary>
  [PublicAPI]
  public interface IExampleTestcontainers : ITestcontainersContainer
  {
    /// <summary>
    /// Gets the username.
    /// </summary>
    [PublicAPI]
    string Username { get; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    [PublicAPI]
    string Password { get; }
  }
}
