---
title: Core Framework v3 API
title-version: 3.0.0
---

The API for Core Framework v3 is spread across many classes and interfaces, contained in a handful of namespaces.

Below is a list of the most commonly used classes, organized by activity type. The navigation to the left is organized by namespace and type. Using the "filter" list can be a quick way to find a specific thing you're looking for, whether it be a class, a method, a property, etc.

## For unit test authors

+----------------------------------------------------------------------------------------------+---------------------------------------------------------------------------------------------+
| Common Classes                                                                               | Common Interfaces
+==============================================================================================+=============================================================================================+
| [`AssemblyFixtureAttribute`](/v3/3.0.0/Xunit.AssemblyFixtureAttribute.html)<br />            | [`IAsyncLifetime`](/v3/3.0.0/Xunit.IAsyncLifetime.html)<br />
| [`Assert`](/v3/3.0.0/Xunit.Assert.html)<br />                                                | [`IClassFixture<T>`](/v3/3.0.0/Xunit.IClassFixture-1.html)<br />
| [`BeforeAfterTestAttribute`](/v3/3.0.0/Xunit.v3.BeforeAfterTestAttribute.html)<br />         | [`ICollectionFixture<T>`](/v3/3.0.0/Xunit.ICollectionFixture-1.html)<br />
| [`CaptureConsoleAttribute`](/v3/3.0.0/Xunit.CaptureConsoleAttribute.html)<br />              | [`ITestOutputHelper`](/v3/3.0.0/Xunit.ITestOutputHelper.html)<br />
| [`CaptureTraceAttribute`](/v3/3.0.0/Xunit.CaptureTraceAttribute.html)<br />                  | [`ITestPipelineStartup`](/v3/3.0.0/Xunit.v3.ITestPipelineStartup.html)<br />
| [`CollectionAttribute`](/v3/3.0.0/Xunit.CollectionAttribute.html)<br />                      | [`IXunitSerializable`](/v3/3.0.0/Xunit.Sdk.IXunitSerializable.html)<br />
| [`CollectionDefinitionAttribute`](/v3/3.0.0/Xunit.CollectionDefinitionAttribute.html)<br />  | [`IXunitSerializationInfo`](/v3/3.0.0/Xunit.Sdk.IXunitSerializationInfo.html)<br />
| [`FactAttribute`](/v3/3.0.0/Xunit.FactAttribute.html)<br />                                  | [`IXunitSerializer`](/v3/3.0.0/Xunit.Sdk.IXunitSerializer.html)
| [`InlineDataAttribute`](/v3/3.0.0/Xunit.InlineDataAttribute.html)<br />                      |
| [`MemberDataAttribute`](/v3/3.0.0/Xunit.MemberDataAttribute.html)<br />                      |
| [`Record`](/v3/3.0.0/Xunit.Record.html)<br />                                                |
| [`TestContext`](/v3/3.0.0/Xunit.TestContext.html)<br />                                      |
| [`TestPipelineStartupAttribute`](/v3/3.0.0/Xunit.v3.TestPipelineStartupAttribute.html)<br /> |
| [`TheoryAttribute`](/v3/3.0.0/Xunit.TheoryAttribute.html)<br />                              |
| [`TheoryDataRow<T1>`](/v3/3.0.0/Xunit.TheoryDataRow-1.html)<br />                            |
| [`TheoryDataRow<T1, T2>`](/v3/3.0.0/Xunit.TheoryDataRow-2.html)<br />                        |
| [`TheoryDataRow<T1, T2, T3>`](/v3/3.0.0/Xunit.TheoryDataRow-3.html)                          |

## For extensibility authors

+---------------------------------------------------------------------------------------------------------------+--------------------------------------------------------------------------------------------------------------+
| Common Classes                                                                                                | Common Interfaces
+===============================================================================================================+==============================================================================================================+
| [`DataAttribute`](/v3/3.0.0/Xunit.v3.DataAttribute.html)<br />                                                | [`IJsonDeserializable`](/v3/3.0.0/Xunit.Sdk.IJsonDeserializable.html)<br />
| [`JsonArraySerializer`](/v3/3.0.0/Xunit.Sdk.JsonArraySerializer.html)<br />                                   | [`IJsonSerializable`](/v3/3.0.0/Xunit.Sdk.IJsonSerializable.html)<br />
| [`JsonDeserializer`](/v3/3.0.0/Xunit.Sdk.JsonDeserializer.html)<br />                                         | [`IRunnerReporter`](/v3/3.0.0/Xunit.Runner.Common.IRunnerReporter.html)<br />
| [`JsonObjectSerializer`](/v3/3.0.0/Xunit.Sdk.JsonObjectSerializer.html)<br />                                 | [`IRunnerReporterMessageHandler`](/v3/3.0.0/Xunit.Runner.Common.IRunnerReporterMessageHandler.html)<br />
| [`LongLivedMarshalByRefObject`](/v3/3.0.0/Xunit.Sdk.LongLivedMarshalByRefObject.html)<br />                   | [`ISelfExecutingXunitTestCase`](/v3/3.0.0/Xunit.v3.ISelfExecutingXunitTestCase.html)<br />
| [`RegisterRunnerReporterAttribute`](/v3/3.0.0/Xunit.Runner.Common.RegisterRunnerReporterAttribute.html)<br /> | [`ITestFramework`](/v3/3.0.0/Xunit.v3.ITestFramework.html)<br />
| [`RegisterXunitSerializerAttribute`](/v3/3.0.0/Xunit.Sdk.RegisterXunitSerializerAttribute.html)<br />         | [`ITestFrameworkDiscoverer`](/v3/3.0.0/Xunit.v3.ITestFrameworkDiscoverer.html)<br />
| [`TestFramework`](/v3/3.0.0/Xunit.v3.TestFramework.html)<br />                                                | [`ITestFrameworkExecutor`](/v3/3.0.0/Xunit.v3.ITestFrameworkExecutor.html)<br />
| [`TestFrameworkAttribute`](/v3/3.0.0/Xunit.TestFrameworkAttribute.html)<br />                                 | [`IXunitTestCaseDiscoverer`](/v3/3.0.0/Xunit.v3.IXunitTestCaseDiscoverer.html)
| [`TestFrameworkDiscoverer<TTestClass>`](/v3/3.0.0/Xunit.v3.TestFrameworkDiscoverer-1.html)<br />              |
| [`TestFrameworkExecutor<TTestCase>`](/v3/3.0.0/Xunit.v3.TestFrameworkExecutor-1.html)<br />                   |
| [`TestIntrospectionHelper`](/v3/3.0.0/Xunit.v3.TestIntrospectionHelper.html)                                  |

## For runner authors

+-----------------------------------------------------------------------------------------------------+----------------------------------------------------------------------------------------------------+
| Common Classes                                                                                      | Common Interfaces
+=====================================================================================================+====================================================================================================+
| [`AssemblyMetadata`](/v3/3.0.0/Xunit.Runner.Common.AssemblyMetadata.html)<br />                     | [`IAssemblyMetadata`](/v3/3.0.0/Xunit.Sdk.IAssemblyMetadata.html)<br />
| [`AssemblyRunner`](/v3/3.0.0/Xunit.SimpleRunner.AssemblyRunner.html)<br />                          | [`IErrorMetadata`](/v3/3.0.0/Xunit.Sdk.IErrorMetadata.html)<br />
| [`AssemblyUtility`](/v3/3.0.0/Xunit.AssemblyUtility.html)<br />                                     | [`IExecutionMetadata`](/v3/3.0.0/Xunit.Sdk.IExecutionMetadata.html)<br />
| [`ConfigReader`](/v3/3.0.0/Xunit.Runner.Common.ConfigReader.html)<br />                             | [`IExecutionSummaryMetadata`](/v3/3.0.0/Xunit.Sdk.IExecutionSummaryMetadata.html)<br />
| [`ExecutionSink`](/v3/3.0.0/Xunit.Runner.Common.ExecutionSink.html)<br />                           | [`ITestCaseMetadata`](/v3/3.0.0/Xunit.Sdk.ITestCaseMetadata.html)<br />
| [`ExecutionSinkOptions`](/v3/3.0.0/Xunit.Runner.Common.ExecutionSinkOptions.html)<br />             | [`ITestClassMetadata`](/v3/3.0.0/Xunit.Sdk.ITestClassMetadata.html)<br />
| [`FrontControllerFindAndRunSettings`](/v3/3.0.0/Xunit.FrontControllerFindAndRunSettings.html)<br /> | [`ITestCollectionMetadata`](/v3/3.0.0/Xunit.Sdk.ITestCollectionMetadata.html)<br />
| [`FrontControllerFindSettings`](/v3/3.0.0/Xunit.FrontControllerFindSettings.html)<br />             | [`ITestMetadata`](/v3/3.0.0/Xunit.Sdk.ITestMetadata.html)<br />
| [`FrontControllerRunSettings`](/v3/3.0.0/Xunit.FrontControllerRunSettings.html)<br />               | [`ITestMethodMetadata`](/v3/3.0.0/Xunit.Sdk.ITestMethodMetadata.html)<br />
| [`MessageMetadataCache`](/v3/3.0.0/Xunit.Runner.Common.MessageMetadataCache.html)<br />             | [`ITestResultMessage`](/v3/3.0.0/Xunit.Sdk.ITestResultMessage.html)
| [`XunitFilters`](/v3/3.0.0/Xunit.Runner.Common.XunitFilters.html)<br />                             |
| [`XunitFrontController`](/v3/3.0.0/Xunit.XunitFrontController.html)<br />                           |
| [`XunitProject`](/v3/3.0.0/Xunit.Runner.Common.XunitProject.html)<br />                             |
| [`XunitProjectAssembly`](/v3/3.0.0/Xunit.Runner.Common.XunitProjectAssembly.html)                   |
