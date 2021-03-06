﻿using System;
using System.Collections.Generic;
using Helios.Topology;

namespace Helios.Net
{
    /// <summary>
    /// Class used to manage a cluster of servers
    /// </summary>
    public interface IClusterManager : IEnumerable<INode>
    {
        /// <summary>
        /// Are they any servers available?
        /// </summary>
        /// <returns>true if there are, false otherwise</returns>
        bool HasNext();

        /// <summary>
        /// Move onto the next healthy node
        /// </summary>
        /// <returns>An INode instance which will be used by an IConnectionBuilder
        /// instance to create an IConnection transport</returns>
        INode Next();

        /// <summary>
        /// Notifies the cluster manager that an error occurred
        /// with one of its nodes
        /// </summary>
        /// <param name="node">the INode that experienced an error</param>
        /// <param name="exc">the Exception or issue</param>
        void ErrorOccurred(INode node, Exception exc = null);

        void Add(INode node);

        void Remove(INode node);

        bool Exists(INode node);
    }
}
