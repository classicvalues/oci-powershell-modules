/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170907
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.EmailService.Requests;
using Oci.EmailService.Responses;
using Oci.EmailService.Models;

namespace Oci.EmailService.Cmdlets
{
    [Cmdlet("Get", "OCIEmailSuppressionsList")]
    [OutputType(new System.Type[] { typeof(Oci.EmailService.Models.SuppressionSummary), typeof(Oci.EmailService.Responses.ListSuppressionsResponse) })]
    public class GetOCIEmailSuppressionsList : OCIEmailCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID for the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The request ID for tracing from the system")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The email address of the suppression.")]
        public string EmailAddress { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Search for suppressions that were created within a specific date range, using this parameter to specify the earliest creation date for the returned list (inclusive). Specifying this parameter without the corresponding `timeCreatedLessThan` parameter will retrieve suppressions created from the given `timeCreatedGreaterThanOrEqualTo` to the current time, in ""YYYY-MM-ddThh:mmZ"" format with a Z offset, as defined by RFC 3339.

**Example:** 2016-12-19T16:39:57.600Z")]
        public System.Nullable<System.DateTime> TimeCreatedGreaterThanOrEqualTo { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Search for suppressions that were created within a specific date range, using this parameter to specify the latest creation date for the returned list (exclusive). Specifying this parameter without the corresponding `timeCreatedGreaterThanOrEqualTo` parameter will retrieve all suppressions created before the specified end date, in ""YYYY-MM-ddThh:mmZ"" format with a Z offset, as defined by RFC 3339.

**Example:** 2016-12-19T16:39:57.600Z")]
        public System.Nullable<System.DateTime> TimeCreatedLessThan { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the opc-next-page response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. `1` is the minimum, `1000` is the maximum. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. The `TIMECREATED` value returns the list in in descending order by default. The `EMAILADDRESS` value returns the list in ascending order by default. Use the `SortOrderQueryParam` to change the direction of the returned list of items.")]
        public System.Nullable<Oci.EmailService.Requests.ListSuppressionsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending or descending order.")]
        public System.Nullable<Oci.EmailService.Requests.ListSuppressionsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListSuppressionsRequest request;

            try
            {
                request = new ListSuppressionsRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRequestId = OpcRequestId,
                    EmailAddress = EmailAddress,
                    TimeCreatedGreaterThanOrEqualTo = TimeCreatedGreaterThanOrEqualTo,
                    TimeCreatedLessThan = TimeCreatedLessThan,
                    Page = Page,
                    Limit = Limit,
                    SortBy = SortBy,
                    SortOrder = SortOrder
                };
                IEnumerable<ListSuppressionsResponse> responses = GetRequestDelegate().Invoke(request);
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
            IEnumerable<ListSuppressionsResponse> DefaultRequest(ListSuppressionsRequest request) => Enumerable.Repeat(client.ListSuppressions(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListSuppressionsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListSuppressionsResponse response;
        private delegate IEnumerable<ListSuppressionsResponse> RequestDelegate(ListSuppressionsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
