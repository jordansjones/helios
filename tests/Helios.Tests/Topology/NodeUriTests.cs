﻿using System;
using System.Net;
using Helios.Topology;
using Xunit;

namespace Helios.Tests.Topology
{
    
    public class NodeUriTests
    {
        #region Setup / Teardown



        #endregion

        #region Tests

        [Fact]
        public void Should_convert_valid_tcp_INode_to_NodeUri()
        {
            //arrange
            var testNode =
                NodeBuilder.BuildNode().Host(IPAddress.Loopback).WithPort(1337).WithTransportType(TransportType.Tcp);

            //act
            var nodeUri = new NodeUri(testNode);

            //assert
            Assert.Equal(testNode.Port, nodeUri.Port);
            Assert.Equal(testNode.Host.ToString(), nodeUri.Host);
            Assert.Equal("tcp", nodeUri.Scheme);
            Assert.True(nodeUri.IsLoopback);
        }

        [Fact]
        public void Should_convert_valid_tcp_NodeUri_to_INode()
        {
            //arrange
            var nodeUriStr = "tcp://127.0.0.1:1337/";
            var nodeUri = new Uri(nodeUriStr);

            //act
            var node = NodeUri.GetNodeFromUri(nodeUri);

            //assert
            Assert.NotNull(node);
            Assert.Equal(nodeUri.Host, node.Host.ToString());
            Assert.Equal(nodeUri.Port, node.Port);
            Assert.Equal(nodeUri.Scheme, NodeUri.GetProtocolStringForTransportType(node.TransportType));
        }

        [Fact]
        public void Should_convert_valid_UDP_INode_to_NodeUri()
        {
            //arrange
            var testNode =
                NodeBuilder.BuildNode().Host(IPAddress.Loopback).WithPort(1337).WithTransportType(TransportType.Udp);

            //act
            var nodeUri = new NodeUri(testNode);

            //assert
            Assert.Equal(testNode.Port, nodeUri.Port);
            Assert.Equal(testNode.Host.ToString(), nodeUri.Host);
            Assert.Equal("udp", nodeUri.Scheme);
            Assert.True(nodeUri.IsLoopback);
        }
        

        [Fact]
        public void Should_convert_valid_UDP_NodeUri_to_INode()
        {
            //arrange
            var nodeUriStr = "udp://127.0.0.1:1337/";
            var nodeUri = new Uri(nodeUriStr);

            //act
            var node = NodeUri.GetNodeFromUri(nodeUri);

            //assert
            Assert.NotNull(node);
            Assert.Equal(nodeUri.Host, node.Host.ToString());
            Assert.Equal(nodeUri.Port, node.Port);
            Assert.Equal(nodeUri.Scheme, NodeUri.GetProtocolStringForTransportType(node.TransportType));
        }

        #endregion
    }
}
