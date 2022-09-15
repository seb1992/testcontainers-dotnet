namespace DotNet.Testcontainers.Builders
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using Docker.DotNet.Models;
  using DotNet.Testcontainers.Configurations;
  using DotNet.Testcontainers.Containers;
  using DotNet.Testcontainers.Images;
  using DotNet.Testcontainers.Networks;
  using DotNet.Testcontainers.Volumes;

  /// <summary>
  /// This class represents the fluent Testcontainers builder. Each change creates a new instance of <see cref="TestcontainersBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" />.
  /// With this behaviour we can reuse previous configured configurations and create similar Testcontainers with only little effort.
  /// </summary>
  /// <example>
  /// <code>
  ///   var builder = new TestcontainersBuilder&lt;TestcontainersContainer&gt;()
  ///     .WithName(&quot;nginx&quot;)
  ///     .WithImage(&quot;nginx&quot;)
  ///     .WithEntrypoint(&quot;...&quot;)
  ///     .WithCommand(&quot;...&quot;);
  ///   <br />
  ///   var http = builder
  ///     .WithPortBinding(80, 08)
  ///     .Build();
  ///   <br />
  ///   var https = builder
  ///     .WithPortBinding(443, 443)
  ///     .Build();
  /// </code>
  /// </example>
  /// <typeparam name="TBuilderEntity">The builder entity.</typeparam>
  /// <typeparam name="TContainerEntity">The container entity.</typeparam>
  /// <typeparam name="TConfigurationEntity">The configuration entity.</typeparam>
  public abstract class TestcontainersBuilder<TBuilderEntity, TContainerEntity, TConfigurationEntity> : AbstractBuilder<TBuilderEntity, TContainerEntity, TConfigurationEntity>, ITestcontainersBuilder<TBuilderEntity, TContainerEntity>, ICloneable<TBuilderEntity, ITestcontainersConfiguration>
    where TContainerEntity : ITestcontainersContainer
    where TConfigurationEntity : ITestcontainersConfiguration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TestcontainersBuilder{TBuilderEntity, TContainerEntity, TConfigurationEntity}" /> class.
    /// </summary>
    /// <param name="dockerResourceConfiguration">The Docker resource configuration.</param>
    protected TestcontainersBuilder(TConfigurationEntity dockerResourceConfiguration)
      : base(dockerResourceConfiguration)
    {
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity ConfigureContainer(Action<TContainerEntity> moduleConfiguration)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithImage(string image)
    {
      return this.WithImage(new DockerImage(image));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithImage(IDockerImage image)
    {
      return this.Clone(new TestcontainersConfiguration(image: PrependHubImageNamePrefix(image)));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithName(string name)
    {
      return this.Clone(new TestcontainersConfiguration(name: name));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithHostname(string hostname)
    {
      return this.Clone(new TestcontainersConfiguration(hostname: hostname));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithWorkingDirectory(string workingDirectory)
    {
      return this.Clone(new TestcontainersConfiguration(workingDirectory: workingDirectory));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithEntrypoint(params string[] entrypoint)
    {
      return this.Clone(new TestcontainersConfiguration(entrypoint: entrypoint));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithCommand(params string[] command)
    {
      return this.Clone(new TestcontainersConfiguration(command: command));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithEnvironment(string name, string value)
    {
      var environments = new Dictionary<string, string> { { name, value } };
      return this.Clone(new TestcontainersConfiguration(environments: environments));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithEnvironment(IReadOnlyDictionary<string, string> environments)
    {
      return this.Clone(new TestcontainersConfiguration(environments: environments));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithExposedPort(int port)
    {
      return this.WithExposedPort(port.ToString(CultureInfo.InvariantCulture));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithExposedPort(string port)
    {
      var exposedPorts = new Dictionary<string, string> { { port, port } };
      return this.Clone(new TestcontainersConfiguration(exposedPorts: exposedPorts));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(int port, bool assignRandomHostPort = false)
    {
      return this.WithPortBinding(port.ToString(CultureInfo.InvariantCulture), assignRandomHostPort);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(int hostPort, int containerPort)
    {
      return this.WithPortBinding(hostPort.ToString(CultureInfo.InvariantCulture), containerPort.ToString(CultureInfo.InvariantCulture));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(string port, bool assignRandomHostPort = false)
    {
      var hostPort = assignRandomHostPort ? "0" : port;
      return this.WithPortBinding(hostPort, port);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPortBinding(string hostPort, string containerPort)
    {
      var portBindings = new Dictionary<string, string> { { containerPort, hostPort } };
      return this.Clone(new TestcontainersConfiguration(portBindings: portBindings));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithMount(string source, string destination)
    {
      return this.WithBindMount(source, destination);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithMount(string source, string destination, AccessMode accessMode)
    {
      return this.WithBindMount(source, destination, accessMode);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithBindMount(string source, string destination)
    {
      return this.WithBindMount(source, destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithBindMount(string source, string destination, AccessMode accessMode)
    {
      var mounts = new IMount[] { new BindMount(source, destination, accessMode) };
      return this.Clone(new TestcontainersConfiguration(mounts: mounts));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(string source, string destination)
    {
      return this.WithVolumeMount(source, destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(string source, string destination, AccessMode accessMode)
    {
      return this.WithVolumeMount(new DockerVolume(source), destination, accessMode);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(IDockerVolume source, string destination)
    {
      return this.WithVolumeMount(source, destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithVolumeMount(IDockerVolume source, string destination, AccessMode accessMode)
    {
      var mounts = new IMount[] { new VolumeMount(source, destination, accessMode) };
      return this.Clone(new TestcontainersConfiguration(mounts: mounts));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithTmpfsMount(string destination)
    {
      return this.WithTmpfsMount(destination, AccessMode.ReadWrite);
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithTmpfsMount(string destination, AccessMode accessMode)
    {
      var mounts = new IMount[] { new TmpfsMount(destination, accessMode) };
      return this.Clone(new TestcontainersConfiguration(mounts: mounts));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetwork(string id, string name)
    {
      return this.WithNetwork(new DockerNetwork(id, name));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetwork(IDockerNetwork dockerNetwork)
    {
      var networks = new[] { dockerNetwork };
      return this.Clone(new TestcontainersConfiguration(networks: networks));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetworkAliases(params string[] networkAliases)
    {
      return this.WithNetworkAliases(networkAliases.AsEnumerable());
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithNetworkAliases(IEnumerable<string> networkAliases)
    {
      return this.Clone(new TestcontainersConfiguration(networkAliases: networkAliases));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithAutoRemove(bool autoRemove)
    {
      return this.Clone(new TestcontainersConfiguration(autoRemove: autoRemove));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithPrivileged(bool privileged)
    {
      return this.Clone(new TestcontainersConfiguration(privileged: privileged));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithRegistryAuthentication(string registryEndpoint, string username, string password)
    {
      return this.Clone(new TestcontainersConfiguration(dockerRegistryAuthenticationConfiguration: new DockerRegistryAuthenticationConfiguration(registryEndpoint, username, password)));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithOutputConsumer(IOutputConsumer outputConsumer)
    {
      return this.Clone(new TestcontainersConfiguration(outputConsumer: outputConsumer));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithWaitStrategy(IWaitForContainerOS waitStrategy)
    {
      return this.Clone(new TestcontainersConfiguration(waitStrategies: waitStrategy.Build()));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithCreateContainerParametersModifier(Action<CreateContainerParameters> parameterModifier)
    {
      var parameterModifiers = new[] { parameterModifier };
      return this.Clone(new TestcontainersConfiguration(parameterModifiers: parameterModifiers));
    }

    /// <inheritdoc cref="ITestcontainersBuilder{TBuilderEntity, TContainerEntity}" />
    public TBuilderEntity WithStartupCallback(Func<IRunningDockerContainer, CancellationToken, Task> startupCallback)
    {
      return this.Clone(new TestcontainersConfiguration(startupCallback: startupCallback));
    }

    /// <inheritdoc cref="ICloneable{TBuilderEntity, ITestcontainersConfiguration}" />
    public abstract TBuilderEntity Clone(ITestcontainersConfiguration dockerResourceConfiguration);

    private static IDockerImage PrependHubImageNamePrefix(IDockerImage image)
    {
      if (string.IsNullOrEmpty(TestcontainersSettings.HubImageNamePrefix))
      {
        return image;
      }

      if (!string.IsNullOrEmpty(image.GetHostname()))
      {
        return image;
      }

      return new DockerImage(image.Repository, image.Name, image.Tag, TestcontainersSettings.HubImageNamePrefix);
    }
  }
}
