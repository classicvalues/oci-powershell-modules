/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190325
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatacatalogService.Requests;
using Oci.DatacatalogService.Responses;
using Oci.DatacatalogService.Models;

namespace Oci.DatacatalogService.Cmdlets
{
    [Cmdlet("Get", "OCIDatacatalogDataAssetsList")]
    [OutputType(new System.Type[] { typeof(Oci.DatacatalogService.Models.DataAssetCollection), typeof(Oci.DatacatalogService.Responses.ListDataAssetsResponse) })]
    public class GetOCIDatacatalogDataAssetsList : OCIDataCatalogCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.")]
        public string CatalogId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire display name given. The match is not case sensitive.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match display name pattern given. The match is not case sensitive. For Example : /folders?displayNameContains=Cu.* The above would match all folders with display name that starts with ""Cu"".")]
        public string DisplayNameContains { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the specified lifecycle state. The value is case insensitive.")]
        public System.Nullable<Oci.DatacatalogService.Models.LifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Time that the resource was created. An [RFC3339](https://tools.ietf.org/html/rfc3339) formatted datetime string.")]
        public System.Nullable<System.DateTime> TimeCreated { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Time that the resource was updated. An [RFC3339](https://tools.ietf.org/html/rfc3339) formatted datetime string.")]
        public System.Nullable<System.DateTime> TimeUpdated { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the user who created the resource.")]
        public string CreatedById { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the user who updated the resource.")]
        public string UpdatedById { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique external identifier of this resource in the external source system.")]
        public string ExternalKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The key of the object type.")]
        public string TypeKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to return in a data asset summary response.")]
        public System.Collections.Generic.List<Oci.DatacatalogService.Requests.ListDataAssetsRequest.FieldsEnum> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. If no value is specified TIMECREATED is default.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListDataAssetsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListDataAssetsRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListDataAssetsRequest request;

            try
            {
                request = new ListDataAssetsRequest
                {
                    CatalogId = CatalogId,
                    DisplayName = DisplayName,
                    DisplayNameContains = DisplayNameContains,
                    LifecycleState = LifecycleState,
                    TimeCreated = TimeCreated,
                    TimeUpdated = TimeUpdated,
                    CreatedById = CreatedById,
                    UpdatedById = UpdatedById,
                    ExternalKey = ExternalKey,
                    TypeKey = TypeKey,
                    Fields = Fields,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListDataAssetsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.DataAssetCollection, true);
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
            IEnumerable<ListDataAssetsResponse> DefaultRequest(ListDataAssetsRequest request) => Enumerable.Repeat(client.ListDataAssets(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListDataAssetsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListDataAssetsResponse response;
        private delegate IEnumerable<ListDataAssetsResponse> RequestDelegate(ListDataAssetsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
