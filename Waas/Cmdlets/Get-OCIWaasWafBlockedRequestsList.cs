/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20181116
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.WaasService.Requests;
using Oci.WaasService.Responses;
using Oci.WaasService.Models;

namespace Oci.WaasService.Cmdlets
{
    [Cmdlet("Get", "OCIWaasWafBlockedRequestsList")]
    [OutputType(new System.Type[] { typeof(Oci.WaasService.Models.WafBlockedRequest), typeof(Oci.WaasService.Responses.ListWafBlockedRequestsResponse) })]
    public class GetOCIWaasWafBlockedRequestsList : OCIWaasCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the WAAS policy.")]
        public string WaasPolicyId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter that limits returned events to those occurring on or after a date and time, specified in RFC 3339 format. If unspecified, defaults to 30 minutes before receipt of the request.")]
        public System.Nullable<System.DateTime> TimeObservedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter that limits returned events to those occurring before a date and time, specified in RFC 3339 format.")]
        public System.Nullable<System.DateTime> TimeObservedLessThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return in a paginated call. If unspecified, defaults to `10`.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The value of the `opc-next-page` response header from the previous paginated call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter stats by the Web Application Firewall feature that triggered the block action. If unspecified, data for all WAF features will be returned.")]
        public System.Collections.Generic.List<Oci.WaasService.Requests.ListWafBlockedRequestsRequest.WafFeatureEnum> WafFeature { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListWafBlockedRequestsRequest request;

            try
            {
                request = new ListWafBlockedRequestsRequest
                {
                    WaasPolicyId = WaasPolicyId,
                    OpcRequestId = OpcRequestId,
                    TimeObservedGreaterThanOrEqualTo = TimeObservedGreaterThanOrEqualTo,
                    TimeObservedLessThan = TimeObservedLessThan,
                    Limit = Limit,
                    Page = Page,
                    WafFeature = WafFeature
                };
                IEnumerable<ListWafBlockedRequestsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
                }
                if(!ParameterSetName.Equals(AllPageSet) && !ParameterSetName.Equals(LimitSet) && response.OpcNextPage != null)
                {
                    WriteWarning("This operation supports pagination and not all resources were returned. Re-run using the -All option to auto paginate and list all resources.");
                }
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

        private RequestDelegate GetRequestDelegate()
        {
            IEnumerable<ListWafBlockedRequestsResponse> DefaultRequest(ListWafBlockedRequestsRequest request) => Enumerable.Repeat(client.ListWafBlockedRequests(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListWafBlockedRequestsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListWafBlockedRequestsResponse response;
        private delegate IEnumerable<ListWafBlockedRequestsResponse> RequestDelegate(ListWafBlockedRequestsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
