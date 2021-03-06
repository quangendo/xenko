// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
namespace Sockets.Plugin.Abstractions
{
    /// <summary>
    /// The connection state of an interface.
    /// </summary>
    enum CommsInterfaceStatus
    {
        /// <summary>
        /// The state of the interface can not be determined.
        /// </summary>
        Unknown,

        /// <summary>
        /// The interface is connected. 
        /// </summary>
        Connected,

        /// <summary>
        /// The interface is disconnected.
        /// </summary>
        Disconnected,
    }
}
