namespace Testcontainers.Module.Example.Tests
{
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Containers;
  using DotNet.Testcontainers.Images;
  using Xunit;

  public sealed class ExampleTestcontainersTest
  {
    private const string Username = "FOO";

    private const string Password = "Bar";

    private static readonly IDockerImage Image = new DockerImage("httpd");

    /// <summary>
    /// TODO:
    /// 1) With...() order is important.
    /// 2) Build() calls base class implementation (With...() returns new instance).
    /// </summary>
    private readonly IExampleTestcontainers testcontainers = new ExampleTestcontainersBuilder()
      .WithUsername(string.Empty)
      .WithPassword(string.Empty)
      .WithImage(Image)
      .WithUsername(Username)
      .WithPassword(Password)
      .Build();

    private readonly ITestcontainersContainer testcontainers2 = new TestcontainersBuilder()
      .WithImage(Image)
      .Build();

    private readonly ITestcontainersContainer testcontainers3 = new TestcontainersBuilder<TestcontainersContainer>()
      .WithImage(Image)
      .Build();

    // TODO:
    // private readonly ITestcontainersBuilder<TestcontainersContainer> builder = new TestcontainersBuilder<TestcontainersContainer>();

    [Fact]
    public void ShouldSetUsernameAndPassword()
    {
      Assert.Equal(Username, this.testcontainers.Username);
      Assert.Equal(Password, this.testcontainers.Password);
    }

    [Fact]
    public void ShouldNotBeNull()
    {
      Assert.NotNull(this.testcontainers2);
      Assert.NotNull(this.testcontainers3);
    }
  }
}
