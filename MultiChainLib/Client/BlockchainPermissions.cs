using System;

namespace MultiChainLib.Client
{
    [Flags]
    public enum BlockchainPermissions
    {
        None = 0,
        Connect = 1,
        Send = 2,
        Receive = 4,
        Issue = 8,
        Mine = 16,
        Admin = 32
    }
}