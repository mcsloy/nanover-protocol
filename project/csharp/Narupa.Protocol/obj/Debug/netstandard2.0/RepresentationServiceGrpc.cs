// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: narupa/protocol/instance/representation_service.proto
// </auto-generated>
// Original file comments:
// Copyright (c) Alex Jamieson-Binnie. All rights reserved.
// Licensed under the GPL. See License.txt in the project root for license information.
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Narupa.Protocol.Instance {
  public static partial class RepresentationService
  {
    static readonly string __ServiceName = "narupa.protocol.instance.RepresentationService";

    static readonly grpc::Marshaller<global::Narupa.Protocol.Instance.SetRepresentationRequest> __Marshaller_narupa_protocol_instance_SetRepresentationRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Narupa.Protocol.Instance.SetRepresentationRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Narupa.Protocol.Instance.SetRepresentationResponse> __Marshaller_narupa_protocol_instance_SetRepresentationResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Narupa.Protocol.Instance.SetRepresentationResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Narupa.Protocol.Instance.SetRepresentationRequest, global::Narupa.Protocol.Instance.SetRepresentationResponse> __Method_SetRepresentation = new grpc::Method<global::Narupa.Protocol.Instance.SetRepresentationRequest, global::Narupa.Protocol.Instance.SetRepresentationResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SetRepresentation",
        __Marshaller_narupa_protocol_instance_SetRepresentationRequest,
        __Marshaller_narupa_protocol_instance_SetRepresentationResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Narupa.Protocol.Instance.RepresentationServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RepresentationService</summary>
    public abstract partial class RepresentationServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Narupa.Protocol.Instance.SetRepresentationResponse> SetRepresentation(global::Narupa.Protocol.Instance.SetRepresentationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for RepresentationService</summary>
    public partial class RepresentationServiceClient : grpc::ClientBase<RepresentationServiceClient>
    {
      /// <summary>Creates a new client for RepresentationService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RepresentationServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for RepresentationService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RepresentationServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RepresentationServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RepresentationServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Narupa.Protocol.Instance.SetRepresentationResponse SetRepresentation(global::Narupa.Protocol.Instance.SetRepresentationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetRepresentation(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Narupa.Protocol.Instance.SetRepresentationResponse SetRepresentation(global::Narupa.Protocol.Instance.SetRepresentationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SetRepresentation, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Narupa.Protocol.Instance.SetRepresentationResponse> SetRepresentationAsync(global::Narupa.Protocol.Instance.SetRepresentationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetRepresentationAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Narupa.Protocol.Instance.SetRepresentationResponse> SetRepresentationAsync(global::Narupa.Protocol.Instance.SetRepresentationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SetRepresentation, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RepresentationServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RepresentationServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RepresentationServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SetRepresentation, serviceImpl.SetRepresentation).Build();
    }

    /// <summary>Register service method implementations with a service binder. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RepresentationServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SetRepresentation, serviceImpl.SetRepresentation);
    }

  }
}
#endregion
