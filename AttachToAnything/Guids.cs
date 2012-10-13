// Guids.cs
// MUST match guids.h

using System;

namespace AttachToAnything
{
    public static class GuidList
    {
        public const string AttachToAnythingPackageString = "ef909810-3edb-49c8-81a1-1f05310780c7";
        public const string AttachToAnythingCommandSetString = "65ba0228-4ea4-439d-ad77-8279243d8371";

        public static readonly Guid AttachToAnythingCommandSet = new Guid(AttachToAnythingCommandSetString);
    };
}