/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190111
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.UsageService.Requests;
using Oci.UsageService.Responses;
using Oci.UsageService.Models;

namespace Oci.UsageService.Cmdlets
{
    [Cmdlet("Get", "OCIUsageRewardsList")]
    [OutputType(new System.Type[] { typeof(Oci.UsageService.Models.RewardCollection), typeof(Oci.UsageService.Responses.ListRewardsResponse) })]
    public class GetOCIUsageRewardsList : OCIRewardsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the tenancy.")]
        public string TenancyId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The subscriptionId for which rewards information is requested for.")]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique, Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListRewardsRequest request;

            try
            {
                request = new ListRewardsRequest
                {
                    TenancyId = TenancyId,
                    SubscriptionId = SubscriptionId,
                    OpcRequestId = OpcRequestId
                };

                response = client.ListRewards(request).GetAwaiter().GetResult();
                WriteOutput(response, response.RewardCollection);
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

        private ListRewardsResponse response;
    }
}
