/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20210101
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, 2021, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.AilanguageService.Requests;
using Oci.AilanguageService.Responses;
using Oci.AilanguageService.Models;

namespace Oci.AilanguageService.Cmdlets
{
    [Cmdlet("Invoke", "OCIAilanguageDetectDominantLanguage")]
    [OutputType(new System.Type[] { typeof(Oci.AilanguageService.Models.DetectDominantLanguageResult), typeof(Oci.AilanguageService.Responses.DetectDominantLanguageResponse) })]
    public class InvokeOCIAilanguageDetectDominantLanguage : OCIAIServiceLanguageCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details to make a language detection detect call. Example: `{""text"": ""If an emerging growth company, indicate by check mark if the registrant has elected not             to use the extended transition period for complying""}`")]
        public DetectDominantLanguageDetails DetectDominantLanguageDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            DetectDominantLanguageRequest request;

            try
            {
                request = new DetectDominantLanguageRequest
                {
                    DetectDominantLanguageDetails = DetectDominantLanguageDetails,
                    OpcRequestId = OpcRequestId
                };

                response = client.DetectDominantLanguage(request).GetAwaiter().GetResult();
                WriteOutput(response, response.DetectDominantLanguageResult);
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

        private DetectDominantLanguageResponse response;
    }
}
