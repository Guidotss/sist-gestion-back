namespace Infraestructure.Adapters;

public static class Envs
{
    public static string Get(string key) => Environment.GetEnvironmentVariable(key) ?? throw new InvalidOperationException($"Environment variable {key} not found");
}