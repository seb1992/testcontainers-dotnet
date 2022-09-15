namespace DotNet.Testcontainers.Builders
{
  // TODO: Find a suitable name.
  internal interface ICloneable<out TBuilderEntity, in TConfigurationEntity>
  {
    TBuilderEntity Clone(TConfigurationEntity dockerResourceConfiguration);
  }
}
