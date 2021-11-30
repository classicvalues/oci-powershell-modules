/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20201101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatabasemanagementService.Requests;
using Oci.DatabasemanagementService.Responses;
using Oci.DatabasemanagementService.Models;

namespace Oci.DatabasemanagementService.Cmdlets
{
    [Cmdlet("New", "OCIDatabasemanagementDbManagementPrivateEndpoint")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.DbManagementPrivateEndpoint), typeof(Oci.DatabasemanagementService.Responses.CreateDbManagementPrivateEndpointResponse) })]
    public class NewOCIDatabasemanagementDbManagementPrivateEndpoint : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details used to create a new Database Management private endpoint.")]
        public CreateDbManagementPrivateEndpointDetails CreateDbManagementPrivateEndpointDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateDbManagementPrivateEndpointRequest request;

            try
            {
                request = new CreateDbManagementPrivateEndpointRequest
                {
                    CreateDbManagementPrivateEndpointDetails = CreateDbManagementPrivateEndpointDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateDbManagementPrivateEndpoint(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DbManagementPrivateEndpoint);
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

        private CreateDbManagementPrivateEndpointResponse response;
    }
}
