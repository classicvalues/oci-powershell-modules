/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20180115
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DnsService.Requests;
using Oci.DnsService.Responses;
using Oci.DnsService.Models;

namespace Oci.DnsService.Cmdlets
{
    [Cmdlet("New", "OCIDnsResolverEndpoint")]
    [OutputType(new System.Type[] { typeof(Oci.DnsService.Models.ResolverEndpoint), typeof(Oci.DnsService.Responses.CreateResolverEndpointResponse) })]
    public class NewOCIDnsResolverEndpoint : OCIDnsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the target resolver.")]
        public string ResolverId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for creating a new resolver endpoint. This parameter also accepts subtype <Oci.DnsService.Models.CreateResolverVnicEndpointDetails> of type <Oci.DnsService.Models.CreateResolverEndpointDetails>.")]
        public CreateResolverEndpointDetails CreateResolverEndpointDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies to operate only on resources that have a matching DNS scope.")]
        public System.Nullable<Oci.DnsService.Models.Scope> Scope { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateResolverEndpointRequest request;

            try
            {
                request = new CreateResolverEndpointRequest
                {
                    ResolverId = ResolverId,
                    CreateResolverEndpointDetails = CreateResolverEndpointDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId,
                    Scope = Scope
                };

                response = client.CreateResolverEndpoint(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ResolverEndpoint);
                FinishProcessing(response);
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            TerminatingErrorDuringExecution(new OperationCanceledException("Cmdlet execution interrupted"));
        }

        private CreateResolverEndpointResponse response;
    }
}
