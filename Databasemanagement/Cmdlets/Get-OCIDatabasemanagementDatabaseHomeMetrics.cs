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
    [Cmdlet("Get", "OCIDatabasemanagementDatabaseHomeMetrics")]
    [OutputType(new System.Type[] { typeof(Oci.DatabasemanagementService.Models.DatabaseHomeMetrics), typeof(Oci.DatabasemanagementService.Responses.GetDatabaseHomeMetricsResponse) })]
    public class GetOCIDatabasemanagementDatabaseHomeMetrics : OCIDbManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the Managed Database.")]
        public string ManagedDatabaseId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The start time for the time range to retrieve the health metrics of a Managed Database in UTC in ISO-8601 format, which is ""yyyy-MM-dd'T'hh:mm:ss.sss'Z'"".")]
        public string StartTime { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The end time for the time range to retrieve the health metrics of a Managed Database in UTC in ISO-8601 format, which is ""yyyy-MM-dd'T'hh:mm:ss.sss'Z'"".")]
        public string EndTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetDatabaseHomeMetricsRequest request;

            try
            {
                request = new GetDatabaseHomeMetricsRequest
                {
                    ManagedDatabaseId = ManagedDatabaseId,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetDatabaseHomeMetrics(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DatabaseHomeMetrics);
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

        private GetDatabaseHomeMetricsResponse response;
    }
}
