/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.ArtifactsService.Requests;
using Oci.ArtifactsService.Responses;
using Oci.ArtifactsService.Models;

namespace Oci.ArtifactsService.Cmdlets
{
    [Cmdlet("Get", "OCIArtifactsContainerImageSignature")]
    [OutputType(new System.Type[] { typeof(Oci.ArtifactsService.Models.ContainerImageSignature), typeof(Oci.ArtifactsService.Responses.GetContainerImageSignatureResponse) })]
    public class GetOCIArtifactsContainerImageSignature : OCIArtifactsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/iaas/Content/General/Concepts/identifiers.htm) of the container image signature.

Example: `ocid1.containersignature.oc1..exampleuniqueID`")]
        public string ImageSignatureId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetContainerImageSignatureRequest request;

            try
            {
                request = new GetContainerImageSignatureRequest
                {
                    ImageSignatureId = ImageSignatureId,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetContainerImageSignature(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ContainerImageSignature);
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

        private GetContainerImageSignatureResponse response;
    }
}