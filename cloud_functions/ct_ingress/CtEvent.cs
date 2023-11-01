using System;

namespace GoogleFunction
{
    public class CtEvent
    {
        public string NotificationType { get; set; }
        public string ProjectKey { get; set; }
        public Resource Resource { get; set; }
        public object ResourceUserProvidedIdentifiers { get; set; }
        public int Version { get; set; }
        public int OldVersion { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class Resource
    {
        public string TypeId { get; set; }
        public string Id { get; set; }
    }
}
