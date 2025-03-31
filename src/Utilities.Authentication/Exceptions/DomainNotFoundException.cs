using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Utilities.Authentication.Tests")]

namespace Utilities.Authentication.Exceptions;

internal class DomainNotFoundException(string domain) : Exception($"Domain:  {domain} not found.");
