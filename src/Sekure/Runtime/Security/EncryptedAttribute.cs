using System;

namespace Sekure.Runtime.Security;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class EncryptedAttribute : Attribute
{
}
