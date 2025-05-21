namespace Test
{
    using System;
    using System.Collections.Generic;

    public class ComplexObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public Metadata Metadata { get; set; }
        public SensitiveData SensitiveData { get; set; }
        public List<ChildObject> Children { get; set; }
    }

    public class Metadata
    {
        public string Version { get; set; }
        public string Author { get; set; }
        public DateTime LastModified { get; set; }
        public InternalMetadata InternalMetadata { get; set; }
    }

    public class InternalMetadata
    {
        public int ProcessId { get; set; }
        public int ThreadId { get; set; }
        public DebugInfo DebugInfo { get; set; }
    }

    public class DebugInfo
    {
        public string StackTrace { get; set; }
        public long MemoryUsage { get; set; }
        public double ProcessorTime { get; set; }
    }

    public class SensitiveData
    {
        public string ApiKey { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class ChildObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
