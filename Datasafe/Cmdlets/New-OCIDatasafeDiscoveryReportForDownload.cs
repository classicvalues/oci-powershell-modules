/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181201
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.DatasafeService.Requests;
using Oci.DatasafeService.Responses;
using Oci.DatasafeService.Models;

namespace Oci.DatasafeService.Cmdlets
{
    [Cmdlet("New", "OCIDatasafeDiscoveryReportForDownload")]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.DatasafeService.Responses.GenerateDiscoveryReportForDownloadResponse) })]
    public class NewOCIDatasafeDiscoveryReportForDownload : OCIDataSafeCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the sensitive data model.")]
        public string SensitiveDataModelId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details to generate a downloadable discovery report.")]
        public GenerateDiscoveryReportForDownloadDetails GenerateDiscoveryReportForDownloadDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GenerateDiscoveryReportForDownloadRequest request;

            try
            {
                request = new GenerateDiscoveryReportForDownloadRequest
                {
                    SensitiveDataModelId = SensitiveDataModelId,
                    GenerateDiscoveryReportForDownloadDetails = GenerateDiscoveryReportForDownloadDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.GenerateDiscoveryReportForDownload(request).GetAwaiter().GetResult();
                WriteOutput(response, CreateWorkRequestObject(response.OpcWorkRequestId));
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

        private GenerateDiscoveryReportForDownloadResponse response;
    }
}