﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ThreatDetectionTests : SqlTestsBase
    {
        protected Management.Storage.StorageManagementClient GetStorageV2Client()
        {
            var client = TestBase.GetServiceClient<Management.Storage.StorageManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected override void SetupManagementClients()
        {
            var sqlCSMClient = GetSqlClient();
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            var resourcesClient = GetResourcesClient();
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, storageV2Client, resourcesClient, authorizationClient);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionDatabaseGetDefualtPolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionDatabaseGetDefualtPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionDatabaseUpdatePolicy()
        {
            RunPowerShellTest("Test-ThreatDetectionDatabaseUpdatePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void DisablingThreatDetection()
        {
            RunPowerShellTest("Test-DisablingThreatDetection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void InvalidArgumentsThreatDetection()
        {
            RunPowerShellTest("Test-InvalidArgumentsThreatDetection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void ThreatDetectionOnSawaServer()
        {
            RunPowerShellTest("Test-ThreatDetectionOnSawaServer");
        }
    }
}
