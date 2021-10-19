/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210930
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.WafService.Requests;
using Oci.WafService.Responses;
using Oci.WafService.Models;

namespace Oci.WafService.Cmdlets
{
    [Cmdlet("New", "OCIWafNetworkAddressList")]
    [OutputType(new System.Type[] { typeof(Oci.WafService.Models.NetworkAddressList), typeof(Oci.WafService.Responses.CreateNetworkAddressListResponse) })]
    public class NewOCIWafNetworkAddressList : OCIWafCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Details for the new NetworkAddressList. This parameter also accepts subtypes <Oci.WafService.Models.CreateNetworkAddressListVcnAddressesDetails>, <Oci.WafService.Models.CreateNetworkAddressListAddressesDetails> of type <Oci.WafService.Models.CreateNetworkAddressListDetails>.")]
        public CreateNetworkAddressListDetails CreateNetworkAddressListDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            CreateNetworkAddressListRequest request;

            try
            {
                request = new CreateNetworkAddressListRequest
                {
                    CreateNetworkAddressListDetails = CreateNetworkAddressListDetails,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.CreateNetworkAddressList(request).GetAwaiter().GetResult();
                WriteOutput(response, response.NetworkAddressList);
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

        private CreateNetworkAddressListResponse response;
    }
}