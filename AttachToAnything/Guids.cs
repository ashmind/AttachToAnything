// Guids.cs
// MUST match guids.h

using System;

namespace AttachToAnything
{
    public static class GuidList
    {
        public const string PackageString = "ef909810-3edb-49c8-81a1-1f05310780c7";
        public const string CommandSetString = "65ba0228-4ea4-439d-ad77-8279243d8371";

        public static readonly Guid Commands = new Guid(CommandSetString);
    };
}