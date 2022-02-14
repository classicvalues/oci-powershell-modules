/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 0.0.1
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2022, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AnnouncementsService.Requests;
using Oci.AnnouncementsService.Responses;
using Oci.AnnouncementsService.Models;

namespace Oci.AnnouncementsService.Cmdlets
{
    [Cmdlet("Remove", "OCIAnnouncementsserviceAnnouncementSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.AnnouncementsService.Responses.DeleteAnnouncementSubscriptionResponse) })]
    public class RemoveOCIAnnouncementsserviceAnnouncementSubscription : OCIAnnouncementSubscriptionCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the announcement subscription.")]
        public string AnnouncementSubscriptionId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The locking version, used for optimistic concurrency control.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the complete request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Ignore confirmation and force the Cmdlet to complete action.")]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmDelete("OCIAnnouncementsserviceAnnouncementSubscription", "Remove"))
            {
               return;
            }

            DeleteAnnouncementSubscriptionRequest request;

            try
            {
                request = new DeleteAnnouncementSubscriptionRequest
                {
                    AnnouncementSubscriptionId = AnnouncementSubscriptionId,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.DeleteAnnouncementSubscription(request).GetAwaiter().GetResult();
                WriteOutput(response);
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

        private DeleteAnnouncementSubscriptionResponse response;
    }
}